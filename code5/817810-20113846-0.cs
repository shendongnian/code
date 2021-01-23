    public class SystemComponentFinalResponseWrapper
    {
        public List<SystemComponentFinalseries> series { get; set; }
    }
    public class SystemComponentFinalseries
    {
        public string ts { get; set; }
        public double? prod { get; set; }
        public double? cons { get; set; }
        public List<double?> data { get; set; }
        //public IDictionary<string, string> data { get; set; }
    }
