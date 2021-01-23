    public class Ps
    {
        [XmlArray("ps")]
        public List<object> items { get { return a1; } }
        private readonly List<object> a1 = new List<object>(); 
    }
