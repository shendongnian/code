    public abstract class BaseClass
    {
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
    }
    
    public class Child1 : BaseClass
    {
    }
    
    public class Child2 : BaseClass
    {
    }
    public static class Test
    {
       public static void SetBaseClassValue(BaseClass b)
       {
          b.CreateUser = "John";
       }
    }
    public static class Program
    {
       public static void Main()
       {
          var c1 = new Child1();
          var c2 = new Child2();
          Test.SetBaseClassValue(c1);
          Test.SetBaseClassValue(c2);
          Console.WriteLine(c1.CreateUser);
          Console.WriteLine(c2.CreateUser);
          Console.ReadLine();
       }
    }
