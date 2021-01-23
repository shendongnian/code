    public class Inventory {
        private List<InventoryItem> inner = new List<InventoryItem>();
        public void Add(InventoryItem item) {
            if (inner.Exists(x => x.Name == item.name)) {
                throw new ArgumentException("Duplicate item");
            } else {
                inner.Add(item)
            }
        }
        public List<InventoryItem> OrderedByName() {
            return inner.OrderBy(x => x.Name);
        }
        public List<InventoryItem> OrderedByDate() {
            return inner;
        }
        public InventoryItem this[int i] {
	        get {
	            return inner[i]
	        }
        }
    }
