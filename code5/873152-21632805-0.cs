    public class UploadController : ApiController
    {
        public async Task < HttpResponseMessage > PostFormData() 
        {
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
    
            try 
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
    
                // Show all the key-value pairs.
                foreach(var key in provider.FormData.AllKeys) 
                {
                    foreach(var val in provider.FormData.GetValues(key)) 
                    {
                        var keyValue = string.Format("{0}: {1}", key, val);
                    }
                }
    
                foreach(MultipartFileData fileData in provider.FileData) 
                {
                    var fileName = fileData.Headers.ContentDisposition.FileName;
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            } 
            catch (Exception e) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
    ...
