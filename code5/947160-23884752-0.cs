    abstract class Parent<TReturn> where TReturn : ReturnParent
    {
        public abstract TReturn SomeMethod();    
    }
    class Child : Parent<ReturnChild>
    {
        public override ReturnChild SomeMethod(){}
    }
