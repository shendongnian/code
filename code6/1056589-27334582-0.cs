    public class FList
    {
    [Key]
        public int FListID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public DateTime Posted { get; set; }
        public virtual User User { get; set; }
        public ICollection<FListItem> Items { get; set; }
    
        public virtual ICollection<Item> Items { get; set; }
    
    }
    
    public class Item
    {
    [Key]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public ICollection<FListItem> FLists { get; set; }
    }
