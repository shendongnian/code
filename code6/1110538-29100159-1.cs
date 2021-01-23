     public async Task<bool> UploadFile()
     {
          try
          {
               if (!Request.Content.IsMimeMultipartContent())
               {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
               }
                var provider = new CustomMultipartFormDataStreamProvider(_tempPath);
                await Request.Content.ReadAsMultipartAsync(provider);
                return true; // you can create a custom model and return that instead. bool is used as an example.
            }
            catch (Exception ex)
            {
                throw;
            }
        }
