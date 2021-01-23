    public class MultipleItemsMap : ClassMap<MultipleItems>
    {
        public MultipleItemsMap()
        {
            Id(i => i.id);
            Map(i => i.Total);
            Map(i => i.Discount);
            HasMany(i => i.OrderItems).Access.CamelCaseField(Prefix.Underscore)
                .Cascade.All();
        }
    }
