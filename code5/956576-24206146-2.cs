    public static HttpWebResponse Request (string url, string method, NameValueCollection data = null, CookieContainer cookies = null, bool ajax = true)
        {
            HttpWebRequest request = WebRequest.Create (url) as HttpWebRequest;
            request.Method = method;
            request.Accept = "text/javascript, text/html, application/xml, text/xml, */*";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Host = "steamcommunity.com";
            request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.47 Safari/536.11";
            request.Referer = "http://steamcommunity.com/trade/1";
            if (ajax)
            {
                request.Headers.Add ("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add ("X-Prototype-Version", "1.7");
            }
            // Cookies
            request.CookieContainer = cookies ?? new CookieContainer ();
            // Request data
            if (data != null)
            {
                string dataString = String.Join ("&", Array.ConvertAll (data.AllKeys, key =>
                    String.Format ("{0}={1}", HttpUtility.UrlEncode (key), HttpUtility.UrlEncode (data [key]))
                )
                );
                byte[] dataBytes = Encoding.ASCII.GetBytes (dataString);
                request.ContentLength = dataBytes.Length;
                Stream requestStream = request.GetRequestStream ();
                requestStream.Write (dataBytes, 0, dataBytes.Length);
            }
            // Get the response
            //return request.GetResponse () as HttpWebResponse;
            //EXCEPTION8712905
            double millisecondsDelay = 2000;//10
            //double delayMultiplyFactor = 2;
            int allowedRetries = 10000;//10
            while (true)
            {
                try
                {
                    return request.GetResponse() as HttpWebResponse;
                }
                catch (Exception e)
                {
                    if (e is WebException && allowedRetries-- > 0)
                    {
                        System.Console.WriteLine("Trying to Reconnect...");
                        Thread.Sleep((int)millisecondsDelay);
                        //millisecondsDelay *= delayMultiplyFactor;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
