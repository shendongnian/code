    public class Institution
    {
        private Institution() { }
        public Institution(int organizationId, string name)
        {
            OrganizationId = organizationId;            
            Name = name;
            ReplicationKey = Guid.NewGuid();
            new InstitutionValidator().ValidateAndThrow(this);
        }
        public int Id { get; private set; }
        public string Name { get; private set; }        
        public virtual ICollection<Department> Departments { get; private set; }
        ... other properties    
        public Department AddDepartment(string name)
        {
            var department = new Department(Id, name);
            if (Departments == null) Departments = new List<Department>();
            Departments.Add(department);            
            return department;
        }
        ... other domain operations
    }
