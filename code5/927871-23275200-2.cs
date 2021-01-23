    public class test
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
 
        public string DisplayName { get { return Name1 ?? Name2; } }
    }
