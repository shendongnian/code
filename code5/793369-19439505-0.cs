    [Export(typeof(IPacket))]
    class FirstPacket : IPacket
    {
        public FirstPacket()
        {
            Name = "Joe";
        }
        public string Name { get; set; }
        public string GetInfo()
        {
            return "Name: " + Name;
        }
    }
    [Export(typeof(IPacket))]
    class SecondPacket : IPacket
    {
        public SecondPacket()
        {
            Measurement = 42.42m;
        }
        public decimal Measurement { get; set; }
        public string GetInfo()
        {
            return "Measurement: " + Measurement;
        }
    }
