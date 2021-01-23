     int lengthOfMessage=1024;
     string message = "";
     using (MemoryStream ms = new MemoryStream())
     {
          int numBytesRead;
          while ((numBytesRead = memStream.Read(MessageBytes, 0, lengthOfMessage)) > 0)
          {
                lengthOfMessage = lengthOfMessage - numBytesRead;
                ms.Write(MessageBytes, 0, numBytesRead);
          }
          message = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
     }
