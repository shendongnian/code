    public Image GetImage(string url)
        {
            HttpWebRequest request = GetWebRequest(url);
            var responseData = "";
            if (request == null)
                return null;
            request.Method = "GET";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookieContainer;
            request.UserAgent = RefreshUserAgent();
            request.KeepAlive = true;
            request.AllowAutoRedirect = _allowAutoRedirect;
            request.Referer = _referer;
            request.Timeout = TimeoutInterval;
            //Decode Response
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                return Image.FromStream(response.GetResponseStream());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
