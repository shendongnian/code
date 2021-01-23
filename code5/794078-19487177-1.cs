    public class ListWrapper<T>
    {
        public ListWrapper(INamedEnumerable<T> list)
        {
            List = new List<T>(list);
            Name = list.Name;
        }
        public List<T> List { get; set; }
        public string Name { get; set; }
    }
