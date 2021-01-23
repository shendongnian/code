       public static string HttpGet()
                {
                WebClient client = new WebClient();
    
                // Add a user agent header in case the  
                // requested URI contains a query.
    
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
    
                using (Stream data = client.OpenRead("http://www.google.com/alerts/feeds/11811034629636691510/10685173545303329123"))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string s = reader.ReadToEnd();
    
                    }
                }
            }
