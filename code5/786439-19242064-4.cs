     internal class Poco
     {
       public string Str
       {
         get;
         set;
       }
    }
    internal interface ITest1
    {
       Poco Obj
       {
         get;
         set;
       }
    }
    public class Foo : ITest1
    {
     
       Poco Obj // missing access modifier
       {
         get;
         set;
       }
    }
