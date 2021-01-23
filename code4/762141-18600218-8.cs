    class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class FooCollection : IEnumerable<Foo>
    {
        private List<Foo> list = new List<Foo>();
        public void Add(Foo foo)
        {
            list.Add(foo);
        }
        public Foo this[string name]
        {
            get { return list.Find(f => f.Name == name); }
        }
        public IEnumerator<Foo> GetEnumerator()
        {
            return list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }
    }
