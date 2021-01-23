    class MyItem 
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Nullable { get; set; }  // also, consider making this bool
    }
    class MyList : IEnumerable<MyItem>
    {
        public List<string> Names { get; set; }
        public List<string> DataTypes { get; set; }
        public List<string> Nullables { get; set; }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<MyItem> GetEnumerator()
        {
            // assuming all lists are the same length
            for (int i = 0; i < Names.Count; i++)
                yield return new MyItem {
                    Name = Names[i],
                    DataType = DataTypes[i],
                    Nullable = Nullables[i]
                };
        }
    }
