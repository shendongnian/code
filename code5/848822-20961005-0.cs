    public class Parent
    {    
        [Key]
        public int ParentID {get;set;}
        [InverseProperty("Father")]
        public virtual ICollection<Child> FatherOf {get;set;}
        [InverseProperty("Mother")]
        public virtual ICollection<Child> MotherOf {get;set;}
    }
    public class Child 
    {    
        [Key]
        public int ChildID {get;set;}
        [ForeignKey("Father")]
        public int FatherID {get;set;}
        public virtual Parent Father {get;set;}
        [ForeignKey("Mother")]
        public int MotherID {get;set;}
        public virtual Parent Mother {get;set;}
    }
