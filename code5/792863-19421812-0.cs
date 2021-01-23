    try
    {
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
           
             ... your code goes here....
            
    }
    catch (WebException ex)
            {
            using (WebResponse response = ex.Response)
            {
                var httpResponse = (HttpWebResponse)response;
                using (Stream data = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(data);
                    throw new Exception(sr.ReadToEnd());
                }
            }
        }
