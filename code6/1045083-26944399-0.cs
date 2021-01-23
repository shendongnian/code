       private async void TransferToStorage()
        {
            // Has the file been copied already?
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync("localfile.xml");
                // No exception means it exists
                return;
            }
            catch (System.IO.FileNotFoundException)
            {
                // The file obviously doesn't exist
            }
            // Cant await inside catch, but this works anyway
            StorageFile stopfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///installfile.xml"));
            await stopfile.CopyAsync(ApplicationData.Current.LocalFolder);
        }
