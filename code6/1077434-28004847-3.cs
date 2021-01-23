    namespace WpfApplication1
    {
        public class Item
        {
            public Item(string name)
            {
                Name = name;
            }
    
            public string Name { get; private set; }
        }
    
        public class MyViewModel
        {
            public List<Item> Items
            {
                get 
                {
                    return new List<Item>() { new Item("Thing 1"), new Item("Thing 2") };
                }
            }
        }
    }
