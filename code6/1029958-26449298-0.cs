    public class InventoryItems {
        private List<IInventoryItem> inner = new List<IInventoryItem>();
        public void Add(IInventoryItem item) {
            if (inner.Exists(x => x.Name == item.name)) {
                throw new ArgumentException("Duplicate item");
            } else {
                inner.Add(item)
            }
        }
        public List<IInventoryItem> OrderedByName() {
            return inner.OrderBy(x => x.Name);
        }
        public List<IInventoryItem> OrderedByDate() {
            return inner;
        }
        public IInventoryItem this[int i] {
	        get {
	            return inner[i]
	        }
        }
    }
