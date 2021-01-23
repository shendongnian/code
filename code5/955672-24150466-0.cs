                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(uri);
                //req.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                //req.AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip;
                //req.Method = "GET";
                string source = String.Empty;
                try
                {
                    using (System.Net.WebResponse webResponse = req.GetResponse())
                    {
                        using (HttpWebResponse httpWebResponse = webResponse as HttpWebResponse)
                        {
                            StreamReader reader;
                            if (httpWebResponse.ContentEncoding.ToLower().Contains("gzip"))
                            {
                                reader = new StreamReader(new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress));
                            }
                            else if (httpWebResponse.ContentEncoding.ToLower().Contains("deflate"))
                            {
                                reader = new StreamReader(new DeflateStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress));
                            }
                            else
                            {
                                reader = new StreamReader(httpWebResponse.GetResponseStream());
                            }
                            source = reader.ReadToEnd();
                        }
                    }
                
                req.Abort();
                }
                catch(Exception ex){
                    //received a 404 Error - apparently one of my links is now dead...
                }
