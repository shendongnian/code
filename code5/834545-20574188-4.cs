    public class CartItem {
        private Item _item;
        
        public long Id {get; set;}
        public long ItemId {get ; set;}
        
        public Item Item {
            get {
                return _item ?? (_item = GetItem());
            }
        }
        
        private Item GetItem() {
              return Repository.Get<Item>(ItemId);
        }
    }
