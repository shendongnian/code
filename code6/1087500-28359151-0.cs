    public class BaseClass 
    {
       internal static int intM = 0;
    }
    public class TestAccess 
    {
       static void Main() 
       {
          BaseClass myBase = new BaseClass();   // Ok.
          BaseClass.intM = 444;    // CS0117
       }
    }
