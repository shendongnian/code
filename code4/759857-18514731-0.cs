    public class Rootobject
    {
        public Data data { get; set; }
        public bool success { get; set; }
    }
    
    public class Data
    {
        public FooHugoInfo foohugoinfo { get; set; }
        public FooFritzTask fooFritzTask { get; set; }
    }
    
    public class FooHugoInfo
    {
        public string path { get; set; }
        public int minVersion { get; set; }
        public int maxVersion { get; set; }
    }
    
    public class FooFritzTask
    {
        public string path { get; set; }
        public int minVersion { get; set; }
        public int maxVersion { get; set; }
    }
