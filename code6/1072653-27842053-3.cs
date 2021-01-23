    public abstract class MyClass
    {
       public const string MyConstant = "fortytwo";
    }
    public class MyClass<T> : MyClass
    {
       // stuff
    }
    var doeswork = MyClass.MyConstant; 
