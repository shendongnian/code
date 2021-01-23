    public class Event
    {
        public string Name { get; set; }
        public DateTime Starts { get; set; }
        public override string ToString()
        {
            return Name + " " + Starts.ToString();
        }
    }
