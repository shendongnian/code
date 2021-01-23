    abstract class A { }
    
    class A1 : A
    {
         private static A1 instance;
         public static A1 Instance
         {
             get
             {
                 if( instance == null )
                     instance = new A1();
                 return instance;
             }
         }
         private A1() { }
    }
