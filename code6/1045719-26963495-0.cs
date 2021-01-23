        class Store
        {
            public Store() : this(null) { }
            public Store(string name) {
                 Records = new List<Record>();
            }
            public string name { get; set; }
            public List<Record> Records { get; private set; }
        }
        class Record
        {
            public Record() { }
            public Record(int ID, int Quantity, double Price, string Name) { }
            public int id { get; set; }
            public int quantity { get; set; }
            public double price { get; set; }
            public string name { get; set; }
        }
    }
