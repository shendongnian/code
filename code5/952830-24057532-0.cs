        public void Upload(string file, Uri destination)
        {
           using (WebClient client=new Webclient())
            {
               client.Headers.Add("Content-Type", "binary/octet-stream");
               client.UploadFileAsync(destination, "POST", file);
            }
        }
