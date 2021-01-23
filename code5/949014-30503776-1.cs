    namespace MvcApplication1.Controllers
    {
        public class FileUploadController : ApiController
        {
            // POST api/fileupload
            public void Post()
            {
    			if (HttpContext.Current.Request.Files.AllKeys.Any())
    			{
    				// Get the uploaded image from the Files collection
    				var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
    
    				if (httpPostedFile != null)
    				{
    					// Get the complete file path
    					String fileSavePath = HttpContext.Current.Server.MapPath("~/Content/Images/") + HttpContext.Current.Request.Form["ImageName"].ToString();
    
    					// Save the uploaded file to "UploadedFiles" folder
    					httpPostedFile.SaveAs(fileSavePath);
    				}
    			}
            }        
        }
    }
