    public class Bus
    {
        public string Channel { get; set; }
        public List<String> Label { get; set; }
        public Bus( string channel = "" )
        {
            this.Channel = channel;
            this.Label = new List<string>();
        }
    }
