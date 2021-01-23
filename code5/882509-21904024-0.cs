    public static string isAlive(string url)
    {
       Console.WriteLine("start: Is Alive Test");
       WebRequest request = WebRequest.Create(url);
       try
       {
           using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    		{
    			return Convert.ToString((int)response.StatusCode);
    		}
           
       }
       catch(WebException ex)
       {
           using(HttpWebResponse res  = (HttpWebResponse)ex.Response)
           {
              return Convert.ToString((int)res.StatusCode);
           }
       }
    }
