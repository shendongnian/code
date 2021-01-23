     using (MemoryStream stream = new MemoryStream())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(json);
                            writer.Flush();
                            stream.Position = 0;
    
                            string response = HttpHelper.DoJsonRequest("https://localhost:44300/RestFull.svc/Execute", stream);
    
                            response = response.Remove(0, 1);
                            response = response.Remove(response.Length - 1, 1);
                            response = response.Replace("\\\"", "\"");
                            Data data = HttpHelper.GetObjectFromJson<Data>(response, Types);
                                                
                        }
                    }
