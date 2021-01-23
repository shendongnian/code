     // Informs when full resolution photo has been taken, saves to local media library and the local folder.
    void cam_CaptureImageAvailable(object sender, Microsoft.Devices.ContentReadyEventArgs e)
    {
        string fileName = savedCounter + ".jpg";
        try
        {   // Write message to the UI thread.
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtDebug.Text = "Captured image available, saving photo.";
            });
            // Save photo to the media library camera roll.
            library.SavePictureToCameraRoll(fileName, e.ImageStream);
            // Write message to the UI thread.
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtDebug.Text = "Photo has been saved to camera roll.";
            });
            // Set the position of the stream back to start
            e.ImageStream.Seek(0, SeekOrigin.Begin);
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
            // Write message to the UI thread.
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtDebug.Text = "Photo has been saved to the local folder.";
            });
        }
        finally
        {
            // Close image stream
            e.ImageStream.Close();
        }
    }
    // Informs when thumbnail photo has been taken, saves to the local folder
    // User will select this image in the Photos Hub to bring up the full-resolution. 
    public void cam_CaptureThumbnailAvailable(object sender, ContentReadyEventArgs e)
    {
        string fileName = savedCounter + "_th.jpg";
        try
        {
            // Write message to UI thread.
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtDebug.Text = "Captured image available, saving thumbnail.";
            });
            // Save thumbnail as JPEG to the local folder.
            using (IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream targetStream = isStore.OpenFile(fileName, FileMode.Create, FileAccess.Write))
                {
                    // Initialize the buffer for 4KB disk pages.
                    byte[] readBuffer = new byte[4096];
                    int bytesRead = -1;
                    // Copy the thumbnail to the local folder. 
                    while ((bytesRead = e.ImageStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        targetStream.Write(readBuffer, 0, bytesRead);
                    }
                }
            }
            // Write message to UI thread.
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtDebug.Text = "Thumbnail has been saved to the local folder.";
            });
        }
        finally
        {
        // Close image stream
        e.ImageStream.Close();
        }
    }
