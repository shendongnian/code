    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    
    namespace TestCases.MVC.Controllers
    {
        public class UploadController : ApiController
        {
            [HttpPost]
            public HttpResponseMessage UploadFile()
            {
                HttpResponseMessage response = null;
                if (HttpContext.Current.Request.Files.AllKeys.Any()) {
                    HttpContext.Current.Response.ContentType = "text/HTML";
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedFile"];
    
                    if (httpPostedFile != null) {
    
                        // Validate the uploaded image(optional)
    
                        // Get the complete file path
                        var uploadFilesDir = HttpContext.Current.Server.MapPath("~/UploadedFiles");
                        if (!Directory.Exists(uploadFilesDir)) {
                            Directory.CreateDirectory(uploadFilesDir);
                        }
                        var fileSavePath = Path.Combine(uploadFilesDir, httpPostedFile.FileName);
    
                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);
    
                        response = new HttpResponseMessage(HttpStatusCode.Created) {
                            Content = new StringContent("Uploaded Successfully")
                        };
                    }
                }
                return response;
            }
    
        }
    }
