    public class ShopperMap : EntityTypeConfiguration<Shopper>
    {
        public ShopperMap()
        {
            // other mappings
            // mapping to cart, notice that the WithMany() is empty           
            this.HasRequired(t => t.Cart)
                .WithMany()
                .HasForeignKey(t => t.CartID);
        }
    }
