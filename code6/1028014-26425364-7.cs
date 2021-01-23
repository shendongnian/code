    public class Class1()
    {
        public int Id {get;set;}
        [Required]
        public virtual Class2 Class2 {get;set;}
    }
    public class Class2()
    {
        [Key, ForeignKey("Class1")]
        public int Id {get;set;}
        [Required]
        public virtual Class1 Class1 {get;set;}
    }
