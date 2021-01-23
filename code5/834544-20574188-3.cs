    public class CartItem {
        public long Id {get; set;}
        public long ItemId {get ; set;}
        
        public Item Item {
            get {
                return GetItem();
            }
        }
        
        private Item GetItem() {
              return Repository.Get<Item>(ItemId);
        }
    }
