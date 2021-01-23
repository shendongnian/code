     public class ProjectPerson{
        [Key]
        public int ProjectPersonId { get; set; }
        
        [ForeignKey("Project")]
        public int? ProjectId {get;set;}
        public virtual Project {get;set;}
        [ForeignKey("Person")]
        public int? PersonId {get;set;}
        public virtual Person {get;set;}
        public string RelationshipType {get;set;}
     }
