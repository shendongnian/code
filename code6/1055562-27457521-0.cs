    public class Audio
    {
        public static void start(ListBox device, ListBox process)
        {
            using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
            {
    
                using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                {
                    foreach (var session in sessionEnumerator)
                    {
                        using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
                        using(var session2 = session.QueryInterface<AudioSessionControl2>())
    					{
                            device.Items.Add(audioMeterInformation.GetPeakValue());
    						var processID = session2.ProcessID;
                            process.Items.Add("here I need the processname or ID");
                        }
                    }
                }
            }
    
    
        }
    
        private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }
    }
