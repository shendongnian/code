      public class MyClass
      {
       private static MyClass myClass;
       public int Id
       {
        get
       {
        return myClass.Id;
       }
       set
       {
        myClass.Id = value;
       }
      }
      public static MyClass Get()
      {
       if (myClass == null)
        {
         myClass = NewClass.create();
        }
        return myClass;
      }
     }
     static class NewClass
     {
       public static MyClass create()
       { 
        return new MyClass();
       }
     }
