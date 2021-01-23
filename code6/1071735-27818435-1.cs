     public interface ConstrainedInterface<T> 
     where T: BasePropertyClass
    {
      T MyPropThatMustInheritBasePropertyClass { get; set;}
    }
