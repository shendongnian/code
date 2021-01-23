    public class Device
    {
        public string Software { get; set; }
        public IEnumerable<Sens> Sensors { get; set; }
    }
    public class Sens
    {
        public string Name { get; set; }
        public IEnumerable<Channel> Channels { get; set; }
    }
    public class Channel
    {
        public int Id { get; set; }
    }
