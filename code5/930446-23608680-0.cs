    public static void CopyContentToIsolatedStorage(string file)
            {
                // Obtain the virtual store for the application.
                IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
    
                if (iso.FileExists(file))
                    return;
    
                var fullDirectory = System.IO.Path.GetDirectoryName(file);
                if (!iso.DirectoryExists(fullDirectory))
                    iso.CreateDirectory(fullDirectory);
    
                // Create a stream for the file in the installation folder.
                using (Stream input = Application.GetResourceStream(new Uri(file, UriKind.Relative)).Stream)
                {
                    // Create a stream for the new file in isolated storage.
                    using (IsolatedStorageFileStream output = iso.CreateFile(file))
                    {
                        // Initialize the buffer.
                        byte[] readBuffer = new byte[4096];
                        int bytesRead = -1;
    
                        // Copy the file from the installation folder to isolated storage. 
                        while ((bytesRead = input.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            output.Write(readBuffer, 0, bytesRead);
                        }
                    }
                }
