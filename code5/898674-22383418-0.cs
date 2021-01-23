    public class Center
    {
        public string title { get; set; }
    }
    
    public class East
    {
        public string title { get; set; }
    }
    
    public class Region
    {
        public Center center { get; set; }
        public East east { get; set; }
    }
    
    public class Buttons
    {
        public string save { get; set; }
    }
    
    public class Labels
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string chooseLocale { get; set; }
    }
    
    public class Fields
    {
        public Labels labels { get; set; }
    }
    
    public class RootObject
    {
        public Region region { get; set; }
        public Buttons buttons { get; set; }
        public Fields fields { get; set; }
    }
