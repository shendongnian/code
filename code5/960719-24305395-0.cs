    class Table : IEnumerable<Table>
    {
        public Table()
        {
            _tables = new Dictionary<string, Table>();
        }
    
        public string name { get; set; }
        Dictionary<string, Table> _tables;
        public void Add(string tname)
        {
            _tables.Add(tname, new Table { name = tname });
        }
        public Table this[string tableName]
        {
            get
            {
                Table table;
                if (_tables.TryGetValue(tableName, out table))
                    return table;
                return null;
            }
        }
    
    
        public IEnumerator<Table> GetEnumerator()
        {
            return _tables.Values.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    
    
    void Main()
    {
    	MapInfo mi = new MapInfo();
    	mi.Table["foo"].Dump();
    }
    class MapInfo
    {
        public MapInfo()
        {
            Tables = new Table();
            test();
        }
        private void test()
        {
            Tables.Add("foo");
            Tables.Add("bar");
            Tables.Add("soom");
        }
        public Table Tables { get; set; }
    }
