using DotNetCoreSqlDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSqlDb.Controllers
{
    public class FilesController : Controller
    {
        private readonly IConfiguration _configuration;

        public FilesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Files
        public async Task<IActionResult> Index()
        {
            var files = new List<FileViewModel>();

            try
            {
                string path = _configuration.GetValue<string>("FileSharePath");
                files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                    .Select(x => new FileViewModel
                    {
                        Name = x
                    })
                    .ToList();
            }
            catch (Exception e)
            {

                return View(files);
            }

            return View(files);
        }
    }
}
