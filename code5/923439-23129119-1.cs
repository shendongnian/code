    private static void Main(string[] args)
    {
        using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
        {
            using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
            {
                foreach (var session in sessionEnumerator)
                {
    				using (var simpleVolume = session.QueryInterface<SimpleAudioVolume>())
    				{
    					Assert.IsNotNull(simpleVolume);
    
    					float volume = simpleVolume.MasterVolume;
    					simpleVolume.MasterVolume = 1.0f;
    					simpleVolume.MasterVolume = 0.0f;
    					simpleVolume.MasterVolume = volume;
    
    					bool muted = simpleVolume.IsMuted;
    					simpleVolume.IsMuted = !muted;
    					simpleVolume.IsMuted = muted;
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
