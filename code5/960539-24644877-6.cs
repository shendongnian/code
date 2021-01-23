    public class Project
    {
        private IList<Project> _dependencies;
    
        public virtual int? Id { get; set; }
    
        public virtual string Name { get; set; }
    
        public virtual IList<Project> Dependencies
        {
            get { return _dependencies ?? (_dependencies = new List<Project>()); }
            set { _dependencies = value; }
        }
    
        public virtual Project ParentProject { get; set; }
    
        public virtual Project AddDependency(Project dependency)
        {
            dependency.ParentProject = this;
            Dependencies.Add(dependency);
    
            return this;
        }
    }
