    public AdRequest createAdRequest() {
       return new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)
       .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
       .Build();
    }
