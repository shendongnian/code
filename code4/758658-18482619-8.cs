    class ItemBag
    {
        public virtual void AddSlot(int r, int c)
        {
            
        }
    }
    class DCBag : ItemBag
    {
        public new void AddSlot(int r)
        {
            // we only have a single column
            base.AddSlot(r, 0);
        }
    }
