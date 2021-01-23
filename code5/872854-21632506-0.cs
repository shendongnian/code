    public partial class UploadController : ApiController
    {
        [HttpPost]
        public Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent()) {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
         
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
    
            // Read the form data and return an async task.
            var task = Request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled) {
                        Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }
    
    
                    foreach (MultipartFileData file in provider.FileData) {
                        using (StreamReader fileStream = new StreamReader(file.LocalFileName)){
                            if (provider.FormData.AllKeys.AsParallel().Contains("demo")){
                                //read demo key value from form data successfully
                            }
                            else{
                               //failed to read demo key value from form.
                            }
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "OK");
                });
    
            return task;
        }
    ...
