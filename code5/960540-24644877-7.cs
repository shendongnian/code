    public sealed class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();
            Map(x => x.Name);
    
            References(x => x.ParentProject).Column("ParentProjectId").Cascade.All();
    
            HasMany(x => x.Dependencies).KeyColumn("ParentProjectId").Inverse().Cascade.AllDeleteOrphan();
        }
    }
