    public async Task Foo()
    {
        //code
        try
            {
                MediaCapture mc = new MediaCapture();
                await mc.InitializeAsync();
                if (mc.VideoDeviceController.TorchControl.Supported == true)
                {
                    mc.VideoDeviceController.TorchControl.Enabled = true;
                    if (mc.VideoDeviceController.TorchControl.PowerSupported == true)
                    {
                        mc.VideoDeviceController.TorchControl.PowerPercent = 100;
                    }
                }
            }
            catch(Exception ex)
            {
                //TODO: Report exception to user
            }
    }
