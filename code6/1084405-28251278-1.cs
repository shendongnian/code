        string LoadHtmlFromUrl(string url)
        {
            try
            {
                string htmlCode;
                using (WebClient client = new WebClient())
                {
                    htmlCode = client.DownloadString(url);
                }
                return htmlCode;
            }
            catch (Exception exception)
            {
                //Log Exception
                return null;
            }
        }
