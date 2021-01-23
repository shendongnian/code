        private async Task ListSDCardFileContents()
        {
            List<string> listOfItems = new List<string>();
            
            // List the first /default SD Card whih is on the device. Since we know Windows Phone devices only support one SD card, this should get us the SD card on the phone.
            ExternalStorageDevice sdCard = (await ExternalStorage.GetExternalStorageDevicesAsync()).FirstOrDefault();
            if (sdCard != null)
            {
                // Get the root folder on the SD card.
                ExternalStorageFolder sdrootFolder = sdCard.RootFolder;
                if (sdrootFolder != null)
                {
                    // List all the files on the root folder.
                    var files = await sdrootFolder.GetFilesAsync();
                    if (files != null)
                    {
                        foreach (ExternalStorageFile file in files)
                        {
                            listOfItems.Add(file.Path);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to get root folder on SD card");
                }
            }
            else
            {
                MessageBox.Show("SD Card not found on device");
            }
        }
