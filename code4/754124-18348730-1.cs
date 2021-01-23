    public WriteableBitmap ReadFromIsolatedStorage(string fileName)
        {
            WriteableBitmap bitmap = new WriteableBitmap(100, 100);
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (myIsolatedStorage.FileExists(fileName))
                    {
                        using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                        {
                            // Decode the JPEG stream.                            
                            bitmap = PictureDecoder.DecodeJpeg(fileStream, 100, 100);
                        }
                    }
                }
            }
            catch (Exception)
            {
                RadMessageBox.Show(String.Empty, MessageBoxButtons.OK, "Error Occcured while reading image");                               
            }
            return bitmap;
        }
