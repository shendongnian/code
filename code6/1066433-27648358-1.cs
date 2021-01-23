            context.Response.ContentType = response.ContentType;
            using (WebResponse response = webRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (Stream outputStream = context.Response.OutputStream)
                    {
                        int cnt = 0;
                        byte[] buffer = new byte[4096];
                        do
                        {
                            cnt = responseStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, cnt);
                        } while(cnt != 0);
                    }
                }
            }
