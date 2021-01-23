    public class A 
    {
        …
        public int? BId {get; set;}
        public B NavigationToBProperty {get; set;}
    }
    public class B
    {
        …
        public List<A> ListOfAProperty {get; set;}
    }
