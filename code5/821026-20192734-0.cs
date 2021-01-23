    public class positionsobj
    {
        public positionlist positions { get; set; }
    }
    public class positionlist
    {
        public List<position> position { get; set; }
    }
    public class position
    {
        public float cost_basis { get; set; }
        public DateTime date_acquired { get; set; }
        public int id { get; set; }
        public decimal quantity { get; set; }
        public string symbol { get; set; }
    }
