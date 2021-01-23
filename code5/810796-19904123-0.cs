        public class BasicInventory2 : IInventory
        {
            private Dictionary<int, IItem> items = new Dictionary<int, IItem>();
            public ICollection<IItem> Items
            {
                get
                {
                    return (ICollection<IItem>) items;
                }
            }
        }
