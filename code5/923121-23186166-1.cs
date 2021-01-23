     private static bool InternetAvailable2()
        {
            bool hasNet = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://www.bing.com");
                request.Method = "GET";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.Proxy = null;
                //request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        hasNet = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"NetAvail2");
            }
        }
