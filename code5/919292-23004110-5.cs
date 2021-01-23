    public interface IMyDeviceInfoExtra : IMyDeviceInfo
    {
        bool GpsSignal { get; set; }
    }
    public class MyDeviceInfoWithGps : IMyDeviceInfoExtra
    {
        private IMyDeviceInfo m_theRealStuff;
        private bool m_gpsSignal;
        public MyDeviceInfoWithGps(IMyDeviceInfo theRealStuff)
        {
            m_theRealStuff = theRealStuff;
        }
        // the same thing again ... lots of code duplications
        // The only new member here
        public bool GpsSignal
        {
            get { return m_gpsSignal; }
            set { m_gpsSignal = value; }
        }
    }
