    using (IsolatedStorageFileStream output = iso.CreateFile(MainPage.DB_PATH))
       {
        // Initialize the buffer.
        byte[] readBuffer = new byte[4096];
        int bytesRead = -1;
     
       // Copy the file from the installation folder to the local folder. 
       while ((bytesRead = input.Read(readBuffer, 0, readBuffer.Length)) > 0)
          {
    	output.Write(readBuffer, 0, bytesRead);
          }
        }
