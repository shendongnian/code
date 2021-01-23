    public interface IMyDeviceInfoExtra : IMyDeviceInfo
    {
        bool GpsSignal { get; set; }
    }
    public class MyDeviceInfoWithGps : IMyDeviceInfoExtra
    {
        private IMyDeviceInfo m_theRealStuff;
        public MyDeviceInfoWithGps(IMyDeviceInfo theRealStuff)
        {
            m_theRealStuff = theRealStuff;
        }
        // the same thing again ... lots of code duplications
    }
