    string name = "Arnar Aðalsteinsson"; 
            string encodedName = HttpUtility.UrlEncode(name, Encoding.GetEncoding(1252));
            string url = string.Format("http://website.com/find?name={0}", encodedName);
            HttpClient httpClient = new HttpClient();
            try
            {
                **string result = httpClient.GetStringAsync(url).Result;**
    
            }
            catch (System.AggregateException ex) {
                Debug.WriteLine(ex.Message);
                
            
            }
