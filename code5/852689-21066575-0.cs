    private void DownloadFile( string  someUrl)
            {
    
                byte[] result;
                byte[] buffer = new byte[4096];
    
                WebRequest wr = WebRequest.Create(someUrl);
    
                using (WebResponse response = wr.GetResponse())
                {
                    long contentLentgth = response.ContentLength;  
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (MemoryStream ms  = new MemoryStream())
                        {
                            int count = 0;
                            long totalBytes = 0;  
                            do
                            {
                                count = responseStream.Read(buffer, 0, buffer.Length);
                                totalBytes = totalBytes + count;  
                                ms.Write(buffer, 0, count);
                                using (FileStream file = new FileStream("file.bin", FileMode.Create, System.IO.FileAccess.Write))
                                {
                                    byte[] bytes = new byte[ms.Length];
                                    ms.Read(bytes, 0, (int)ms.Length);
                                    file.Write(bytes, 0, bytes.Length);
                                    ms.Close();
                                }
                                if (totalBytes>contentLentgth/2)
                                {
                                    break;  
                                }
                            } while (count != 0);
                            
                        }
                    }
                }
            }
