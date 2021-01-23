    public class MenuItem
    {
        // Unique id of menu item
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int MenuItemId { get; set; }
        // Tesxt to display on menu item
        [Required]
        public virtual string MenuItemName { get; set; }
        // Sequential display order (within parent item)
        public virtual int DisplayOrder { get; set; }
        // Foreign key value
        public virtual int? ParentMenuItemId { get; set; }
        [ForeignKey("ParentMenuItemId")]
        // Parent menu item
        public virtual MenuItem ParentMenuItem { get; set; }
        // Child menu items
        public virtual ICollection<MenuItem> ChildItems { get; set; }
    }
