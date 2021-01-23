    public class Project
    {
        public virtual int ProjectKey { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual IList<Employee> ProjectOwners { get; set; }
        public virtual IList<Employee> ProjectWorkers { get; set; }
    
        public virtual IList<Employee> AnybodyAssociatedWithThisProject 
        {
            get
            {
                List<Employee> returnItems = new List<Employee>();
                if (null != this.ProjectOwners)
                {
                    returnItems.AddRange(this.ProjectOwners);
                }
                if (null != this.ProjectOwners)
                {
                    returnItems.AddRange(this.ProjectWorkers);
                }
                return returnItems;
            }
        }
    }
    
    
    public class Employee
    {
        public virtual int EmployeeKey { get; set; }
        public virtual string SSN { get; set; }
        public virtual Project OwnedProject { get; set; }
        public virtual Project WorkedOnProject { get; set; }
    }
    
    
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.ProjectKey);
            Map(x => x.ProjectName);
            HasMany(x => x.ProjectOwners)
                .KeyColumn("OwnedProjectKey");
            HasMany(x => x.ProjectWorkers)
                .KeyColumn("WorkedOnProjectKey");
            Table("Project");
        }
    }
    
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.EmployeeKey);
            Map(x => x.SSN);
            References(x => x.OwnedProject).Column("OwnedProjectKey");
            References(x => x.WorkedOnProject).Column("WorkedOnProjectKey");
            Table("Employee");
        }
    }
