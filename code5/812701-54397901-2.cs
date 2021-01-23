		public UploadResult UploadFile(string  fileAddress)
        {
            HttpClient client = new HttpClient();
            
            MultipartFormDataContent form = new MultipartFormDataContent();
            HttpContent content = new StringContent("fileToUpload");
            form.Add(content, "fileToUpload");       
            var stream = new FileStream(fileAddress, FileMode.Open);            
            content = new StreamContent(stream);
            var fileName = 
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "name",
                FileName = Path.GetFileName(fileAddress),                 
            };
            form.Add(content);
            HttpResponseMessage response = null;          
           
            var url = new Uri("http://192.168.10.236:2000/api/Upload2");
            response = (client.PostAsync(url, form)).Result;          
            
        }
 
