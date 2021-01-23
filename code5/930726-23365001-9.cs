    // This class is the same
    public class A 
    {
       public virtual int Id { get; set; }
       public virtual IList<B> Bs { get; set; }
    }
    // here just a reference
    public class B 
    {
       public virtual int Id { get; set; }
       public virtual A A { get; set; }
    }
