    public class FooDataStructure //TODO rename
    {
        private Dictionary<Vector, SortedList<double, List<Something>>> dictionary
            = new Dictionary<Vector, SortedList<double, List<Something>>>();
        public void Add(Foo foo, Something something)
        {
            var vector = new Vector { Angle = foo.Angle, Width = foo.Width };
            SortedList<double, List<Something>> list;
            if (!dictionary.TryGetValue(vector, out list))
            {
                list = new SortedList<double, List<Something>>();
                dictionary.Add(vector, list);
            }
            List<Something> somethings;
            if (!list.TryGetValue(foo.Height, out somethings))
            {
                somethings = new List<Something>();
                list.Add(foo.Height, somethings);
            }
            somethings.Add(something);
        }
        public IEnumerable<Something> Find(
            double angle, double width, double minHeight, double maxHeight)
        {
            var vector = new Vector { Angle = angle, Width = width };
            SortedList<double, List<Something>> list;
            if (!dictionary.TryGetValue(vector, out list))
            {
                return Enumerable.Empty<Something>();
            }
            return list.Keys.GetWithinRange(minHeight, maxHeight)
                .SelectMany(key => list[key]);
        }
    }
