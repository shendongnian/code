    using System;
    using CSCore.CoreAudioAPI;
    
    namespace AudioDetector
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(IsAudioPlaying(GetDefaultRenderDevice()));
                Console.ReadLine();
            }
                    
            public static MMDevice GetDefaultRenderDevice()
            {
                using (var enumerator = new MMDeviceEnumerator())
                {
                    return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
                }
            }
            
            public static bool IsAudioPlaying(MMDevice device)
            {
                using (var meter = AudioMeterInformation.FromDevice(device))
                {
                    return meter.PeakValue > 0;
                }
            }
        }
    }
