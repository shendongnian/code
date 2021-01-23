    public class RootObject2
    {
        public string result { get; set; }
        public Return @return { get; set; }
    }
    public class Return
    {
        public Item high { get; set; }
        public Item low { get; set; }
        public Item avg { get; set; }
        public Item vwap { get; set; }
        public Item vol { get; set; }
        public Item last_local { get; set; }
        public Item last_orig { get; set; }
        public Item last_all { get; set; }
        public Item last { get; set; }
        public Item buy { get; set; }
        public Item sell { get; set; }
        public string item { get; set; }
        public string now { get; set; }
    }
    public class Item
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }
