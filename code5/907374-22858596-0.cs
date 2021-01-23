    public class ProjectMap
    {
        public ProjectMap()
        {
            HasMany(x => x.ProjectDependencies).AsBag().Cascade.AllDeleteOrphan().Fetch.Select().BatchSize(80);
    
            HasMany(x => x.ProjectDependentOf).KeyColumn("DependentProjectId").AsBag().Inverse().Cascade.AllDeleteOrphan().Fetch.Select().BatchSize(80);
    
        }
    }
    
