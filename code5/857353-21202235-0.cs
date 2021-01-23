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
                        using(var session2 = session.QueryInterface<AudioSessionControl2>())
                        {
                            string title = String.Empty;
                            if (session2.IsSystemSoundSession)
                                title = "Systemsounds";
                            else
                                title = session2.Process.MainWindowTitle; //note, that this can be null => see xml comments
    
                            Console.WriteLine("The Process with the ID {0} and title {1} has a volume of {2}%.", session2.ProcessID, title, simpleVolume.MasterVolume * 100);
                        }
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
