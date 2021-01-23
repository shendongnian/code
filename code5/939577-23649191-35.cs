    public class FooViewModel
    {
        public string Name {get; set;} 
        //hey, a domain model class!
        public DomainClass Genre {get;set;} 
    }
    public class DomainClass
    {
        public int Id {get; set;}      
        public string Name {get;set;} 
    }
