    namespace Repository {
        public class InMemoryRepository : IRepository{
            static readonly List<Item> items = new List<Item> {
                new Item("CurrentTaxRate", 20m),
                new Item("CurrentAmount", 100m)
            };
            public Item Get(string name) {
                return items.Single(x => x.Name == name);
            }
        }
    }
    public class Item {
        public Item(string name, decimal value) {
            Name = name;
            Value = value;
        }
        public string Name { get; private set; }
        public decimal Value { get; private set; }
    }
