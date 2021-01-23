    public class ReferenceBase { }
    public class B : ReferenceBase { ... }
    public class C : ReferenceBase { ... }
    public class A {
        public virtual ReferenceBase  Reference { get; set; }
        //implement a custom setter if you want to throw exception
    }
