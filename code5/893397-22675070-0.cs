    public static void MoveReferenceDatabase()
        {
            // Obtain the virtual store for the application.
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
            // Create a stream for the file in the installation folder.
            using (Stream input = Application.GetResourceStream(new Uri("DutchMe.sdf", UriKind.Relative)).Stream)
            {
                // Create a stream for the new file in the local folder.
                using (IsolatedStorageFileStream output = iso.CreateFile("DutchMe.sdf"))
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
            }
        }
