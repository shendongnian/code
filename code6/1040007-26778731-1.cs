    using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                //To obtain response body
                                using (Stream streamResponse = response.GetResponseStream())
                                {
                                    using (StreamReader streamRead = new StreamReader(streamResponse, Encoding.UTF8))
                                    {
                                        var result = streamRead.ReadToEnd();
                                        if (response.Equals("1")) //It's 1 in my case when operation                           is complete!!
                                        {
                                            
                                        }
                                        else
                                        {
                                            
                                        }
                                    }
                                }
                            }
                        }
