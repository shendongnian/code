    public class HeaderMap : ClassMap<Header>
    {
        public HeaderMap()
        {
            Table("Header");
            LazyLoad();
            CompositeId().KeyProperty(x => x.Id1, "Id1")
                         .KeyProperty(x => x.Id2, "Id2");
            Map(x => x.Something).Column("Something");
            HasMany(x => x.Versions).AsBag().KeyColumns.Add("PId1", "PId2");
            // Fetch, Inverse, Cascade depend on your mapping strategy
        }
    }
