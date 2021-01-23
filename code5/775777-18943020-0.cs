    public class Item {
        public Item()
        {
            this.ChildItems = new HashSet<Item>();
        }
    public int Id { get; set; }
    public Nullable<int> ParentItemId { get; set; }
    public string Value { get; set; }
    public virtual Item ParentItem { get; set; }
    public virtual ICollection<Item> ChildItems { get; set; }
