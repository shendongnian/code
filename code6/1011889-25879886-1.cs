       private Stream MakeMemoryStream(Stream stream) {
               // some code emitted here     
                SyncMemoryStream memoryStream = new SyncMemoryStream(0);      // buffered Stream to save off data
                try {
                    //
                    // Now drain the Stream
                    //
                    if (stream.CanRead) {
                        byte [] buffer = new byte[1024];
                        int bytesTransferred = 0;
     
                        int maxBytesToBuffer = (HttpWebRequest.DefaultMaximumErrorResponseLength == -1)?buffer.Length:HttpWebRequest.DefaultMaximumErrorResponseLength*1024;
                        while ((bytesTransferred = stream.Read(buffer, 0, Math.Min(buffer.Length, maxBytesToBuffer))) > 0)
                        {
                            memoryStream.Write(buffer, 0, bytesTransferred);
                            if(HttpWebRequest.DefaultMaximumErrorResponseLength != -1)
                                maxBytesToBuffer -= bytesTransferred;
                        }
                    }
                    memoryStream.Position = 0;
                }
                catch {
                }
                // some other code
                return memoryStream;
            }
