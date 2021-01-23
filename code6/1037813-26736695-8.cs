    [Serializable]
    public class HeadVM
    {
        public List<Heads> data { get; set; }      
    }
    public class Heads
    {
        public int h_id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
    }
