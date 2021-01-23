    class Destination
    {
        public int key {get; set;}
        public List<Destination> nodes {get; set;}
        public Destination(Source source)
        {
            Key = source.Id;
            Nodes = source.Select(s => new Destination(s)).ToList();
        }
    }
