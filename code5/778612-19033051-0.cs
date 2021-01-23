        private async void UploadPhotoButton_Click(object sender, EventArgs e)
        {
            ...
            string theResult = await MyProvider.SendPhotoAsync(pathToFile, new UploadProgressChangedEventHandler(UploadProgressCallback));
            OutputBox.Text = theResult;
        }
        public async Task<string> SendPhotoAsync(string filename, UploadProgressChangedEventHandler changedHandler)
        {
            byte[] response = await PostFileAsync(_url, filename, changedHandler);
            String responsestring = Encoding.ASCII.GetString(response);
            if (responsestring.StartsWith("ERROR:"))
                return responsestring;
            else if (responsestring.Contains("<valid>1</valid>"))
                return "OK";
            else
                return responsestring;
        }
        async Task<byte[]> PostFileAsync(string uri, string filename, UploadProgressChangedEventHandler changedHandler)
        {
            byte[] response = null;
            using (WebClient client = new WebClient())
            {
                client.Headers = GetAuthenticationHeader();
                client.UploadProgressChanged += changedHandler;
                response = await client.UploadFileTaskAsync(new Uri(uri), filename);
            }
            return response;
        }
