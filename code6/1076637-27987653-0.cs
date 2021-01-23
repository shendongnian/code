    public class Box
    {
        public virtual Guid Id { get; set; }
        public virtual IList<Item> Contents { get; protected set; }
        public Box()
        {
            Contents = new List<Item>();
        }
        public void Add(Item item)
        {
            item.Parent = this;
            Contents.Add(item);
        }
    }
