    public class Source
    {
        public int Id { get; set; }
        public List<Source> Children { get; set; }
        public Destination GetDestination()
        {
            var dest = new Destination
            {
                nodes = Children.Select(c => c.GetDestination()).ToList(),
                key = Id
            };
            return dest;
        }
    }
