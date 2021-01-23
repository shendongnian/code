    public class Class1
    {
        public int Id {get;set;}
        public virtual Class2 Class2 {get;set;}
    }
    public class Class2
    {
        public int Id {get;set;}
        public virtual Class1 Class1 {get;set;}
    }
