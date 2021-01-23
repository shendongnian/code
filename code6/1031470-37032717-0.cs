    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            EnableScanner();
        }
    private async void EnableScanner()
        {
            if (await CreateDefaultScannerObject())
            {
                // after successful creation, claim the scanner for exclusive use and enable it so that data reveived events are received.
                if (await ClaimScanner())
                {
                    Task<bool> AsyncSuccess = EnableClaimedScanner();
                    bool x = await AsyncSuccess;
                    if (x)
                    {
                        HookUpEventsClaimedScanner();
                    }
                }
            }
        }
            private async Task<bool> CreateDefaultScannerObject()
        {
            if (scanner == null)
            {
                UpdateOutput("Creating Barcode Scanner object.");
                scanner = await BarcodeScanner.GetDefaultAsync();
                if (scanner != null)
                {
                    UpdateOutput("Default Barcode Scanner created.");
                    UpdateOutput("Device Id is:" + scanner.DeviceId);
                }
                else
                {
                    UpdateOutput("Barcode Scanner not found. Please connect a Barcode Scanner.");
                    return false;
                }
            }
            return true;
        }
        private async Task<bool> EnableClaimedScanner()
        {
            bool result = false;
            try
            {
                await claimedScanner.EnableAsync();
                if (claimedScanner.IsEnabled)
                {
                    claimedScanner.IsDecodeDataEnabled = true;
                    UpdateOutput("ClaimedScanner is now Enabled.");
                    result = true;
                }
                else
                    UpdateOutput("ClaimedScanner wasn't Enabled.");
            }
            catch (Exception ex)
            {
                UpdateOutput( ex.Message);
            }
            return result;
        }
        public void HookUpEventsClaimedScanner()
        {
            claimedScanner.DataReceived += ScannerDataReceived;
            claimedScanner.ReleaseDeviceRequested += ScannerReleaseRequest;
        }
