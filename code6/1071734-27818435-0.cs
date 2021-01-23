    public abstract class ConstrainedClass<T>
       where T: BasePropertyClass
       {
         public T MyPropThatMustInheritBasePropertyClass { get; set;}
       }
