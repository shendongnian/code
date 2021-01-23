    public class NewsMap : ClassMap<News>
        {
            public NewsMap()
            {
                Id(x => x.Id).GeneratedBy.Identity();
                Map(x => x.CreationDate).Not.Nullable();
                HasMany(x => x.DomainNameToNews).Inverse.Cascade.AllDeleteOrphan();
            }
        }
     public class DomainNameToNewsMap : ClassMap<DomainNameToNews>
        {
            public DomainNameToNewsMap()
            {
                Id(x => x.Id).GeneratedBy.Identity();
                References(x => x.News).UniqueKey("UQ_DOMAIN_NEWS");
                References(x => x.DomainName).UniqueKey("UQ_DOMAIN_NEWS");
            }
        }
