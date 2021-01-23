            if (GetWorkingWebBrowser().StatusText != null)
            {
                try
                {
                    WebRequest request = WebRequest.Create(GetWorkingWebBrowser().StatusText);
                    request.Method = "HEAD";
                    using (WebResponse response = request.GetResponse())
                    {
                        if (response.ContentLength > 0 && 
                             !response.ContentType.ToString().ToLower().Contains("text/html"))
                        {
                            dlf.DownloadPath = e.Url; //move url to my form for dwnload
                            dlf.Show(); //show form
                        }
                    }
                }
                catch (UriFormatException)
                {
                }
                catch (WebException)
                {
                }
            }
