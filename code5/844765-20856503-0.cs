        public void ExceptionOccured()
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                Stream _data = client.OpenRead(_apiCallArgs);
                // if exception occurs in Open read method
                WebRequest request = WebRequest.Create("http://www.contoso.com/default.html");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // if exception occurs in get response method
                int a = Convert.ToInt32("anyvariable");
                // if exception occurs here
            }
            catch (Exception ex)
            {
               Type exType = ex.GetBaseException().GetType();
            }
        }
