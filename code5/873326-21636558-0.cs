    public class ItemDetailCollection : List<ItemDetail>
    {
        public ItemDetailCollection(IEnumerable<ItemDetail> items)
            : base(items) { }
    }
