    try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://website.com/service");
                request.Method = "GET";
                StringBuilder data = new StringBuilder();
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    WebResponse errorResponse = ex.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        String errorText = reader.ReadToEnd();
                    }
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
