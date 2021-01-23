    public class GenericClass<T>
    {
        T Owner { get; set; }
    
        public GenericClass(T owner) { Owner = owner; }
    }
    public abstract class MyClassBase<T> where T : MyClassBase<T>
    {
        protected GenericClass<T> MyGenericObject { get; private set; }
        protected MyClassBase() { MyGenericObject = new GenericClass<T>((T)this); }
    }
    public class MyClass1 : MyClassBase<MyClass1>
    {
        public MyClass1() { }
    }
    public class MyClass2 : MyClassBase<MyClass2>
    {
        public MyClass2() { }
    }
