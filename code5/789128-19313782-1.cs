    public abstract class AbstractClass<T> where T : MyClass, new() {
        protected T MyProperty { get; set; }
    }
  
    public class SubClass : AbstractClass<SubclassOfMyClass> {
    }
