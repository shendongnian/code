    public abstract class AbstractMinion<T> : IMinion<T>
        where T : IItem  
    {
        protected Warehouse wh;
        public AbstractMinion(Warehouse wh) {
            this.wh = wh;
        }
        public T GetItemInfo(int id) {
            return wh.GetItemInfo<T>(id);
        }
        public int AddItem(int id) {
            return wh.AddItem<T>(id);
        }
        public int RemoveItem(int id) {
            return wh.RemoveItem<T>(id);
        }
    }
