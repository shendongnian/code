    class Program
    {
        static void Main(string[] args)
        {
            using (var sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render))
            {
                foreach (var session in sessionEnumerator)
    			{
    				Assert.IsNotNull(session);
    
    				using (var session2 = session.QueryInterface<AudioSessionControl2>())
    				using (var audioMeterInformation = session.QueryInterface<AudioMeterInformation>())
    				{	
    					Debug.WriteLine("Process: {0}; Peak: {1:P}", 
    						session2.Process == null ? String.Empty : session2.Process.MainWindowTitle,
    						audioMeterInformation.GetPeakValue()*100);
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
    }
