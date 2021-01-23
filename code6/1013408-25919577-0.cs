    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasMany(x => x.Orders).WithRequired(x => x.Customer)
                                  .HasForeignKey(o => o.CustomerId);
        }
    }
