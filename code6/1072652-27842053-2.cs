    public abstract class ConstClass
    {
       public const string MyConstant = "fortytwo";
    }
    public class MyClass<T> : ConstClass
    {
       // stuff
    }
    var doeswork = MyClass.MyConstant; 
