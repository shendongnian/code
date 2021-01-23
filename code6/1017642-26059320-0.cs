    using (NetworkStream stream = client.GetStream())
        {
             do
             {
               Thread.Sleep(20);
             } while (!stream.DataAvailable);
            
             if (stream.DataAvailable && stream.CanRead)
             {
                  Byte[] data = new Byte[1024];
                  List<byte> allData = new List<byte>();
            
                  do
                  {
                        int numBytesRead = stream.Read(data,0,data.Length);
        
                        if (numBytesRead == data.Length)
                        {
                             allData.AddRange(data);
                        }
                        else if (numBytesRead > 0)
                        {
                             allData.AddRange(data.Take(bytes));
                        }                                    
                   } while (stream.DataAvailable);
              }
        }
          
