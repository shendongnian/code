    public class Config : CurveTracer.IConfig
    {
        public bool Init()
        {
            return true;
        }
        public AppConfig AppConfig { get; set; }
    }
    public class CurveTracer
    {
        public interface IConfig
        {
            bool Init();
            AppConfig AppConfig { get; set; }
        }
    }
    // Are you sure this needs to be a struct? Just add cfgVersion and cfgSerial to CurveTracer.IConfig or make it a class.
    public struct AppConfig
    {
        public string cfgVersion;
        public string cfgSerial;
    };
