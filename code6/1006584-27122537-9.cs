    public static async void RequestFeatureXYZ()
        {
            if (!licenseInformation.ProductLicenses["Your Product ID"].IsActive)
            {
                try
                {
    #if DEBUG
                    StorageFolder installFolder = await Package.Current.InstalledLocation.GetFolderAsync("Assets");
                    StorageFile appSimulatorStorageFile = await installFolder.GetFileAsync("WindowsStoreProxy.xml");                                      
                    await CurrentAppSimulator.ReloadSimulatorAsync(appSimulatorStorageFile);
                    PurchaseResults result = await CurrentAppSimulator.RequestProductPurchaseAsync("Your Product ID");
    #else
                    PurchaseResults result = await CurrentApp.RequestProductPurchaseAsync("Your Product ID");
    #endif
                    // licenseInformation_LicenseChanged(); // (un)comment if you find out that the event does (not) always fire                }
                catch (Exception ex)
                {
                    // handle error or do nothing
                }
            }            
        }
