     public static string GetPageHtml(string link, System.Net.WebProxy proxy = null)
            {
                System.Net.WebClient client = new System.Net.WebClient() { Encoding = Encoding.UTF8 };
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                if (proxy != null)
                {
                    client.Proxy = proxy;
                }
    
                using (client)
                {
                    try
                    {
                        return client.DownloadString(link);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
    
            }
