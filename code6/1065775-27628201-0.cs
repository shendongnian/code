    public class Person {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    
        public virtual GuardianSpirit GuardianSpirit { get; set; }
    }
    
    public class GuardianSpirit {
        [ForeignKey("Person")]
        [DatabaseGenerated( DatabaseGeneratedOption.None )]
        public int PersonID { get; set; }
        public string Name { get; set; }
    
        public virtual Person Person { get; set; }
    }
