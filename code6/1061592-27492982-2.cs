    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }}
        public virtual Item Parent { get; set; } // be sure to make this virtual
        public virtual List<Item> Children { get; set; }
        public virtual ICollection<ItemNode> Ancestors { get; set; }
        public virtual ICollection<ItemNode> Offspring { get; set; }
    }
