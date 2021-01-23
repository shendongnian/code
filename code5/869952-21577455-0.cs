    public string ReadWebReport(string path)
        {
            string str = String.Empty;
            
            HttpWebRequest Request = WebRequest.Create(path) as HttpWebRequest;
            Request.Method = "GET"; //Or PUT, DELETE, POST
            Request.ContentType = "application/x-www-form-urlencoded";
            Request.Proxy = null; //<-- inserted line
            using (HttpWebResponse Response = Request.GetResponse() as HttpWebResponse)
            {
                if (Response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("The request did not complete successfully and returned status code " + Response.StatusCode);
                using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
                {
                    str = Reader.ReadToEnd();
                }
            }
            return str;
        }
