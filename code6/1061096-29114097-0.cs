Ran into this today; there is a simpler workaround than manually "File -> Reset Simulator" and that is to configure your [SetUp] to do it for you automatically:
    using System.Diagnostics;
    [SetUp]
    public override void SetUp()
    {
        const string simulatorId = "2261E5E1-758A-4967-8BF2-181E8099379F"; // iPhone 5s iOS 8.2
        ResetSimulator(simulatorId);
        
        // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
        app = ConfigureApp.iOS.AppBundle(PathToIPA).DeviceIdentifier(simulatorId).EnableLocalScreenshots().ApiKey(Constants.XamarinTestCloudApiKey).StartApp();
    }
    public static void ResetSimulator(string deviceId)
    {
        var shutdownProcess = Process.Start("xcrun", string.Format("simctl shutdown {0}", deviceId));
        shutdownProcess.WaitForExit();
        var eraseProcess = Process.Start("xcrun", string.Format("simctl erase {0}", deviceId));
        eraseProcess.WaitForExit();
    }
