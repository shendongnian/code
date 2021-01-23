    // If you would say that a ComplexCls "is a" Cls, then maybe your inheritance
    // relationship belongs here instead.
    public class ComplexCls : Cls { 
    }
    public class ClsList
    {
      public IReadOnlyCollection<Cls> Items {get;set;}
    }
    
    public class ComplexClsList
    {
      public IReadOnlyCollection<ComplexCls> Items {get;set;}
    }
