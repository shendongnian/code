    using (FtpWebResponse response = request.GetResponse() as FtpWebResponse)
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream))
                    {
                        string responseString = streamReader.ReadToEnd();
                        Byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        memoryStream = new MemoryStream(buffer);
                    }
                    responseStream.Close();
                }
                response.Close();
            }
