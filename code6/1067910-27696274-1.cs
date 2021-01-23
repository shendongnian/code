    public class DataCollection
    {
        public DataItem[] data { get; set; }
        //public List<DataItem> data { get; set; } // This would also work.
        //public HashSet<DataItem> data { get; set; } // This would work too.
    }
    
    public class DataItem
    {
        public float value { get; set; }
        public DateTime time { get; set; } // This would work because the time is in an ISO format I believe so json.net can parse it into DateTime.
    }
