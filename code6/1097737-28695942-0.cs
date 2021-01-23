    public class Item
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    
        public class DetailedItem : Item
        {
            public new string Id
            {
                get { return "newid"; }
            }
        }
