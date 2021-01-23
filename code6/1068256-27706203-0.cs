    public class Source
    {
        public int Id { get; set; }
        public List<Source> Children { get; set; }
        public Destination GetDestination()
        {
            var dest = new Destination
            {
                nodes = new List<Destination>(),
                key = Id
            };
            Children.ForEach(c => dest.nodes.Add(c.GetDestination()));
            return dest;
        }
    }
