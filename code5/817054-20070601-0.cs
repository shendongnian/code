    public class Serie
    {
        public string Name { get; set; }
        public List<long> Data { get; set; }
        public Serie()
        {
            Data = new List<long>();
        }
    }
    public class SeriesCollection
    {
        public List<Serie> Series { get; set; }
        public SeriesCollection()
        {
            Series = new List<Serie>();
        }
    }
