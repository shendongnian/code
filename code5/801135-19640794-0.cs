        private bool UrlIsValid(string url)
        {
            bool response = false;
            HttpWebResponse rep = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                rep = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException we)
            {
                if (we.Status == WebExceptionStatus.ProtocolError)
                    rep = (HttpWebResponse)we.Response;
            }
            if (rep != null)
            {
                try
                {
                    using (Stream strm = rep.GetResponseStream())
                    {
                        response = true;
                    }
                }
                catch (WebException ex)
                {
                    //no need variable is already false if we didnt succeed.
                    //response = false;
                }
            }
            return response;
        }
