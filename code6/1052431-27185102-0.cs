    public sealed class NestedItemsViewModel
    {
        public string Name { get; set; }
        public int[] Items { get; set; }
    }
    public sealed class ViewModel
    {
        private readonly List<int> list = new List<int> { 1, 2, 3, 4 };
        private NestedItemsViewModel[] items;
        public NestedItemsViewModel[] Items
        {
            get
            {
                if (items == null)
                {
                    items = new[]
                    {
                        new NestedItemsViewModel
                        { 
                            Name = "Even",
                            Items = list.Where(x => x % 2 == 0).ToArray() 
                        },
                        new NestedItemsViewModel
                        { 
                            Name = "Odd",
                            Items = list.Where(x => x % 2 != 0).ToArray() 
                        },                        
                    };
                }
                return items;
            }
        }
    }
