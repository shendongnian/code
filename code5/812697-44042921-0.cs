        public void PostImage()
        {
            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();
            byte[] imagebytearraystring = ImageFileToByteArray(@"C:\Users\Downloads\icon.png");
            form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Count()), "profile_pic", "hello1.jpg");
            HttpResponseMessage response = httpClient.PostAsync("your url", form).Result;
            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;
        }
        private byte[] ImageFileToByteArray(string fullFilePath)
        {
            FileStream fs = File.OpenRead(fullFilePath);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return bytes;
        }
