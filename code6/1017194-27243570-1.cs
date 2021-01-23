    // Save a downloaded images to the app’s local folder.
            public async Task saveImage(Stream photoToSave, string imageURL)
            {
                StorageFile photoFile = null;
                try
                {
                    string ext = Path.GetExtension(imageURL.Trim());
                    photoFile = await localFolder.CreateFileAsync(ext, CreationCollisionOption.ReplaceExisting);
                    using (var photoOutputStream = await photoFile.OpenStreamForWriteAsync())
                    {
                        await photoToSave.CopyToAsync(photoOutputStream);
                    }
                }
                catch (Exception e)
                {
                    //Error while saving file
                }
            }
