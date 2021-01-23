    void Main()
    {
        var hello = new MyClass1().subClass.Hello1();
    }
    
    public class MyClass1 : Base<MyClass1.MySubClass1>
    {
        public override MySubClass1 subClass{get;set;}
        
        public class MySubClass1 : Base<MySubClass1>.MySubClass
        {
            public string Hello1() {return "hello1";}    
        }
    }
    
    public abstract class Base<T> where T : Base<T>.MySubClass, new()
    {
        public Base() {subClass = new T();}
        public virtual T subClass {get;set;}
        public abstract class MySubClass
        {
            public string Hello() {return "hello";}
        }
    }
