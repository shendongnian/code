    class Vehicle
    {
        public string Class { get; set; }
        public int Speed { get; set; }
        public bool Active { get; set; }
        public override string ToString()
        {
            return string.Format("Class: {0}, Speed: {1}, Active: {2}", 
                Class, Speed, Active);
        }
    }
