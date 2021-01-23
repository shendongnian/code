    public class A 
    {
       public virtual int Id { get; set; }
       public virtual IList<B> Bs { get; set; }
    }
    
    public class B 
    {
       public virtual int Id { get; set; }
       public virtual IList<A> As { get; set; }
    }
