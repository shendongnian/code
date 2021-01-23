    public class Cart
    {
        public int Id { get; set; }
        public string RefId { get; set; } // PK
        public virtual List<CartItem> CartItems { get; set; }
    
    }
    
    public class CartItem
    {
        public int Id { get; set; } 
        public string RefId { get; set; } // PK
        public string CartRefId { get; set; }
    
        public virtual Cart Cart { get; set; }
    }
    
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            HasKey(t => t.RefId);
            Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
    
    public class CartItemMap : EntityTypeConfiguration<CartItem>
    {
        public CartItemMap()
        {
            HasKey(t => t.RefId);
            Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            HasRequired(t => t.Cart)
                .WithMany(t => t.CartItems)
                .HasForeignKey(t => t.CartRefId);
        }
    }
