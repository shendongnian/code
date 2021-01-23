    using System.IO;
    using System.IO.Compression;
    using System.Web;
    public class MyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public FileContentResult ZipIndex()
        {
            // Render the View output: 
            var viewString = View("TheViewToRender").Capture(ControllerContext);
            // Create a zip file containing the resulting markup
            using (MemoryStream outputStream = new MemoryStream())
            {
                StreamReader sr = new StringReader(viewString);
                using (ZipArchive zip = new ZipArchive(outputStream, ZipArchiveMode.Create, false))
                {
                    ZipArchiveEntry entry = zip.CreateEntry("MyView.html", CompressionLevel.Optimal);
                    using (var entryStream = entry.Open())
                    {
                        sr.BaseStream.CopyTo(entryStream);
                    }
                }
                return File(outputStream.ToArray(), MediaTypeNames.Application.Zip, "Filename.zip");
            }
        }
    }
    
    public static class ActionResultExtensions {
        public static string Capture(this ActionResult result, ControllerContext controllerContext) {
            using (var it = new ResponseCapture(controllerContext.RequestContext.HttpContext.Response)) {
                result.ExecuteResult(controllerContext);
                return it.ToString();
            }
        }
    }
    public class ResponseCapture : IDisposable {
        private readonly HttpResponseBase response;
        private readonly TextWriter originalWriter;
        private StringWriter localWriter;
        public ResponseCapture(HttpResponseBase response) {
            this.response = response;
            originalWriter = response.Output;
            localWriter = new StringWriter();
            response.Output = localWriter;
        }
        public override string ToString() {
            localWriter.Flush();
            return localWriter.ToString();
        }
        public void Dispose() {
            if (localWriter != null) {
                localWriter.Dispose();
                localWriter = null;
                response.Output = originalWriter;
            }
        }
    }
