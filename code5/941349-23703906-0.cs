    public interface MyInterface
    {
       string MethodTwo();
    }
    
    public class A : MyInterface
    {
       ...
    }
    
    public class B : MyInterface
    {
       ...
    }
    
    public static void WriteMessage<T>(T objectA) where T: MyInterface
    {
        var text = objectA.MethodTwo();  //Will Work!
        Console.WriteLine("Text:{0}", text);
    }
