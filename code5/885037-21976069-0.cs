    internal class CustomerMapping : EntityMapping<Customer>
    {
        internal CustomerMapping()
        {
            HasMany(x => x.Wishlist)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
