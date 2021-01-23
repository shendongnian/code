    public class A
    {
       B b {get; set;}
    }
    public class B
    {
        public ICollection<A> As {get; set;} 
    }
