    private static void Main(string[] args)
    {
        using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
        {
            using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
            {
                foreach (var session in sessionEnumerator)
                {
                    using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
                    {
                        Console.WriteLine(audioMeterInformation.GetPeakValue());
                    }
                }
            }
        }
    
        Console.ReadKey();
    }
    
    private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
    {
        using (var enumerator = new MMDeviceEnumerator())
        {
            using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
            {
                Debug.WriteLine("DefaultDevice: " + device.FriendlyName);
                var sessionManager = AudioSessionManager2.FromMMDevice(device);
                return sessionManager;
            }
        }
    }
