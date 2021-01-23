    public bool verifyFile(string filePath)
        {
            bool result = true;
            string Domain = "http://www.SiteName.com/";
            try
            {
                WebRequest webRequest = WebRequest.Create(Domain + filePath);
                webRequest.Timeout = 1200;
                webRequest.Method = "HEAD";
                WebResponse webResponse = webRequest.GetResponse();
                result = webResponse.ContentType.ToString() == "text/html; charset=utf-8" ? false : true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
