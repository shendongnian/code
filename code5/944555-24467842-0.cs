        private void ReadCookies()
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://gmail.com");
            request.CookieContainer = new CookieContainer();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            //Console.WriteLine(response.Headers.ToString());
            //Console.WriteLine(response.StatusCode.GetHashCode());
            CookieCollection IncomingCookies = response.Cookies;
            Console.WriteLine("Listing out {0} cookies received.", IncomingCookies.Count);
            foreach(Cookie cookie in IncomingCookies)
            {
                Console.WriteLine("{0} = {1}", cookie.Name, cookie.Value);
            }
            return;
        }
