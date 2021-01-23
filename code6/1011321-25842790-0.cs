    class BaseClass<T> where T : INested, new()
    {
       public T Nested { get; set; }
       public BaseClass()
       {
           Nested = new T();
       }
    }
    	    
    class Derived : BaseClass<NestedImpl>
    {
       Derived()
       {
           Nested = new NestedImpl();
       }
    
       public class NestedImpl : INested
       {
           public int deeper {get;set;}
       }
    }
