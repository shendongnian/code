    public class BaseEntity
    { 
          
          [Key]
          public virtual int ID { get; set; }
        ...
    }
    public class Person : BaseEntity
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public virtual PersonAddress PersonAddress { get; set; }
        public int? MainPersonID { get; set; }
        public virtual Person MainPerson { get; set; }
        public virtual HashSet<Projects.Project> ManagingProjects { get; set; }
        public virtual HashSet<Projects.Project> AdministratingProjects { get; set; }
        public virtual HashSet<Person> Dependants { get; set; }
    }
    public class PersonAddress
    {
        [Key, ForeignKey("Person")]    
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }    
   
    }
