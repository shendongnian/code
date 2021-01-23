    public class Item
    {
        [Key, Column(Order = 0)]
        public long UserId { get; set; }
    
        [Key, Column(Order = 1)]
        public long ToDoId { get; set; }
    
        public virtual Result Result { get; set; }
    }
    public class Result
    {
        public long Id { get; set; }
        [Required]
        public Item Item { get; set; }
    }
