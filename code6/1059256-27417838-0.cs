                    using (Stream TextRequestStream = UsedWebRequest.GetRequestStream())
                    {
                        TextRequestStream.Write(ByteArray, 0, ByteArray.Length);
                        TextRequestStream.Flush();
                    }               
                    HttpWebResponse TokenWebResponse = (HttpWebResponse)UsedWebRequest.GetResponse();
                    Stream ResponseStream = TokenWebResponse.GetResponseStream();
                    StreamReader ResponseStreamReader = new StreamReader(ResponseStream);
                    string Response = ResponseStreamReader.ReadToEnd();
                    ResponseStreamReader.Close();
                    ResponseStream.Close();
