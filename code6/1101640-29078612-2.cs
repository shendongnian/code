    public void StartUpload(RemoteFileInfo fileInfo)
            {
                
                string filePath = define your filePath, where you want to save the file;           
    
                int chunkSize = 2048;
                byte[] buffer = new byte[chunkSize];
    
                using (System.IO.FileStream writeStream = new System.IO.FileStream(filePath, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write))
                {
                    do
                    {
                        // read bytes from input stream (provided by client)
                        int bytesRead = FileByteStream.Read(buffer, 0, chunkSize);
                        if (bytesRead == 0) break;
    
                        // write bytes to output stream
                        writeStream.Write(buffer, 0, bytesRead);
                    } while (true);
    
                    writeStream.Close();
                }
            }
