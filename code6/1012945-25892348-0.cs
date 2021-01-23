    using Windows.Storage;
    
    ...
    
                // Get the logical root folder for all external storage devices.
                StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;
    
                // Get the first child folder, which represents the SD card.
                StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();
    
                if (sdCard != null)
                {
                    // An SD card is present and the sdCard variable now contains a reference to it.
                }
                else
                {
                    // No SD card is present.
                }
