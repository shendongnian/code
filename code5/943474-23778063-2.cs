        [TestMethod]
        [TestCategory("CoreAudioAPI.Endpoint")]
        public void CanGetAudioMeterInformationPeakValue()
        {
            using (var device = Utils.GetDefaultRenderDevice())
            using (var meter = AudioMeterInformation.FromDevice(device))
            {
                Console.WriteLine(meter.PeakValue);
            }
        }
        [TestMethod]
        [TestCategory("CoreAudioAPI.Endpoint")]
        public void CanGetAudioMeterInformationChannelsPeaks()
        {
            using (var device = Utils.GetDefaultRenderDevice())
            using (var meter = AudioMeterInformation.FromDevice(device))
            {
                for (int i = 0; i < meter.MeteringChannelCount; i++)
                {
                    Console.WriteLine(meter[i]);
                }
            }
        }
