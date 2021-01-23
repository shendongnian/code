    HttpWebRequest request;
            void fileDownloadRadar(string uri, string fileName)
            {
                request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
                request.CookieContainer = new CookieContainer();
                request.AllowAutoRedirect = true;
    
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.ContentType == "")
                {
                    Logger.Write("ContentType is Empty download was not fine !!!!!");
                }
                if ((response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Moved ||
                    response.StatusCode == HttpStatusCode.Redirect) &&
                    response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                {
                    Logger.Write("ContentType is not empty meaning download is fine");
                    using (Stream inputStream = response.GetResponseStream())
                    using (Stream outputStream = File.OpenWrite(fileName))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
    
                    }
                    FinishWebRequest();
                }
                else
                {
                    timer1.Stop();
                    timer3.Start();
                }
            }
