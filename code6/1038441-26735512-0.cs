    // Save photo as JPEG to the local folder.
    using (IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication())
    {
        using (IsolatedStorageFileStream targetStream = isStore.OpenFile(fileName, FileMode.Create, FileAccess.Write))
        {
            // Initialize the buffer for 4KB disk pages.
            byte[] readBuffer = new byte[4096];
            int bytesRead = -1;
            // Copy the image to the local folder. 
            while ((bytesRead = e.ImageStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
            {
                targetStream.Write(readBuffer, 0, bytesRead);
            }
        }
    }
