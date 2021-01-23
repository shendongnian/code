        /// <summary>
        /// Gets a bitmap image stored on the local file system
        /// </summary>
        /// <param name="strIFile">The input file path name</param>
        /// <returns>The requested bitmap image, if successful; else, null</returns>
        public static async Task<BitmapImage> GetBitmapAsFile(string strIFile)
        {
            try
            {
                StorageFile fOut = null;
                BitmapImage biOut = null;
                FileRandomAccessStream fasGet = null;
                if (!strIFile.Equals(""))
                {
                    fOut = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(strIFile);
                    if (fOut != null)
                    {
                        fasGet = (FileRandomAccessStream)await fOut.OpenAsync(FileAccessMode.Read);
                        if (fasGet != null)
                        {
                            biOut = new BitmapImage();
                            if (biOut != null)
                            {
                                await biOut.SetSourceAsync(fasGet);
                                return biOut;
                            }
                            else
                                YourApp.App.ShowMessage(true, "Error", "GetBitmapAsFile", "Bitmap [" + strIFile + "] is not set.");
                        }
                        else
                            YourApp.App.ShowMessage(true, "Error", "GetBitmapAsFile", "File stream [" + strIFile + "] is not set.");
                    }
                }
                else
                    YourApp.App.ShowMessage(true, "Error", "GetBitmapAsFile", "Input file path name is empty.");
            }
            catch (Exception ex)
            {
                YourApp.App.ShowMessage(true, "Error", "GetBitmapAsFile", "[" + strIFile + "] " + ex.Message);
            }
            return null;
        }
