            using (WebResponse response = webRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        int cnt = 0;
                        byte[] buffer = new byte[4096];
                        do
                        {
                            cnt = responseStream.Read(buffer, 0, buffer.Length);
                            memoryStream.Write(buffer, 0, cnt);
                        } while(cnt != 0);
 
                        context.Response.ContentType = response.ContentType;
                        context.Response.BinaryWrite(memoryStream.ToArray());
                    }
                }
            }
