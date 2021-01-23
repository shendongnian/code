    public class Project
    {
        // This attribute is used to ensure GetHashCode always return the same value
        private int? hashCode;
        public virtual int Id { get; set; }
        public virtual ICollection<Project> Dependencies { get; set; }
        public Project()
        {
            this.Dependencies = new HashSet<Project>();
        }
        // This is a simplified but correct implementation of GetHashCode
        public override int GetHashCode()
        {
            if (this.hashCode.HasValue)
            {
                return this.hashCode.Value;
            }
            if (this.Id == 0)
            {
                return (this.hashCode = base.GetHashCode()).Value;
            }
            return (this.hashCode = typeof(Project).GetHashCode() * this.Id * 251).Value;
        }
        public override bool Equals(object obj)
        {
            var p = obj as Project;
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }
            return p.Id == this.Id;
        }
    }
    public class ProjectMapping : ClassMapping<Project>
    {
        public ProjectMapping()
        {
            this.Table("Project");
            this.Id(x => x.Id, mapper => mapper.Generator(Generators.Assigned));
            this.Set(x => x.Dependencies,
                mapper =>
                {
                    mapper.Table("ProjectDependency");
                    mapper.Key(m => m.Column("ProjectId"));
                },
                mapper =>
                {
                    mapper.ManyToMany(m => m.Column("DependencyId"));
                });
        }
    }
