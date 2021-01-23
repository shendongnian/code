    namespace Prometheus.Models
    {
        [Table("People")]
        public class Person : IPerson, INamedEntity
        {
            ...
            [InverseProperty("People")]
            public virtual ICollection<Project> Projects { get; set; }
        }
    }
    
    public class Project :INamedEntity
    {
        ...
        [DisplayName("Echipa proiect")]
        [InverseProperty("Projects")]
        public virtual ICollection<Person> People { get; set; }
    }
