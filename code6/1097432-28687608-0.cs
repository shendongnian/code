    class Program { 
    
    static void Main(...)
    {
      Console.WriteLine( TheOtherClass.AFunction() );
    }
    }
    
    public class TheOtherClass
    {
       public static string AFunction()
       {
          return "A String From this Function. :-) ";
       }
    }
