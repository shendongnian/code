    public class Param
    {
        public Param()
        {
            data = new List<Datum>();
        }
        public string url { get; set; }
        public List<Datum> data { get; }
    }
    
    public class RootObject
    {
        public RootObject()
        {
            @params = new List<Param>();
        }
        public List<Param> @params { get; }
        public string session { get; set; }
        public int id { get; set; }
        public string method { get; set; }
    }
