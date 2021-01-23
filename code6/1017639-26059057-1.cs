          string str;
          using (NetworkStream stream = client.GetStream())
          {
                byte[] data = new byte[1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    
                    int numBytesRead ;
                    while ((numBytesRead = stream.Read(data, 0, data.Length)) > 0)
                    {
                        ms.Write(buffer, 0, numBytesRead);
                        
                    }
                   str = Encoding.ASCII.GetString(ms.ToArray(), 0, ms.Length);
                }
            }
