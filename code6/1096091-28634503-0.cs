     public void UploadFile()
        {
            string fileUrl = @"enter file url here";
            string parameters = @"image=" + Convert.ToBase64String(File.ReadAllBytes(fileUrl));
            WebRequest req = WebRequest.Create(new Uri("location url here"));
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            try
            {
                req.ContentLength = bytes.Length;
                Stream s = req.GetRequestStream();
                s.Write(bytes, 0, bytes.Length);
                s.Close();
            }
            catch (WebException ex)
            {
                throw ex; //Request exception.
            }
            try
            {
                WebResponse res = req.GetResponse();
                StreamReader sr = new StreamReader(req.GetResponseStream());
            }
            catch (WebException ex)
            {
                throw ex; //Response exception.
            }
        }
