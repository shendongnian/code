    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [InverseProperty("Person")]
        public virtual ICollection<Relationship> Relationships { get; set; }
    }
    public class Relationship
    {
        public int ID { get; set; }
        public RelationshipType DependencyType { get; set; }
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        [ForeignKey("RelatedPerson")]
        public int RelatedPersonID { get; set; }
        public virtual Person RelatedPerson { get; set; }
    }
