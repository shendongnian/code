        [HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "Unsupported media type.");
            }
            // Read the file and form data.
            MultipartFormDataMemoryStreamProvider provider = new MultipartFormDataMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            // Extract the fields from the form data.
            string description = provider.FormData["description"];
            int uploadType;
            if (!Int32.TryParse(provider.FormData["uploadType"], out uploadType))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Upload Type is invalid.");
            }
            
            // Check if files are on the request.
            if (!provider.FileStreams.Any())
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No file uploaded.");
            }
            IList<string> uploadedFiles = new List<string>();
            foreach (KeyValuePair<string, Stream> file in provider.FileStreams)
            {
                string fileName = file.Key;
                Stream stream = file.Value;
                
                // Do something with the uploaded file
                UploadManager.Upload(stream, fileName, uploadType, description);
                // Keep track of the filename for the response
                uploadedFiles.Add(fileName);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully Uploaded: " + string.Join(", ", uploadedFiles));
        }
