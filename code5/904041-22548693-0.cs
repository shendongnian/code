    public class STEP
    {
        public string STEP { get; set; }
        public string type { get; set; }
        public string ServiceType { get; set; }
        public string ServiceID { get; set; }
        public string NumberOfStop { get; set; }
        public string BoardId { get; set; }
        public string BoardDesc { get; set; }
        public string BoardDist { get; set; }
        public string AlightId { get; set; }
        public string AlightDesc { get; set; }
        public string AlightDist { get; set; }
    }
    
    public class BusRoute
    {
        public string Solution { get; set; }
        public string Duration { get; set; }
        public string TotalCard { get; set; }
        public string TotalCash { get; set; }
        public string TotalDistance { get; set; }
        public List<STEP> STEPS { get; set; }
        public string TotalStops { get; set; }
        public List<List<string>> PATH { get; set; }
    }
    
    public class RootObject
    {
        public List<BusRoute> BusRoute { get; set; }
    }
    var rootObject = JsonConvert.DeserializeObject<RootObject>(e.Result); <- this works
