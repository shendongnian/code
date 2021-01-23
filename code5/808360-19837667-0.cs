    public static string StartCraling(string URI, string Parameters)
            {
                WebRequest req = WebRequest.Create(URI);
                
                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = "POST";
                
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
                req.ContentLength = bytes.Length;
                
                using (Stream os = req.GetRequestStream())
                {
                    os.Write(bytes, 0, bytes.Length); //Push it out there
                }
    
                using (WebResponse resp = req.GetResponse())
                {
                    using (StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                    {
                        return sr.ReadToEnd().Trim();
                    }
                }
            }
