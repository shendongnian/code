    public class BasicInventory2 : IInventory
    {
        private Dictionary<int, IItem> items;
        public ICollection<IItem> Items
        {
           get { return items.Values; }
        }
    }
