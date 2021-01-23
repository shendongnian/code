    namespace Level1.Level2
    {
        public class MyObject
        {
            public int _Number = 0;
            public MyObject(int number)
            {
                _Number = number;
            }
            public System.Messaging.MessageQueue FunctionA() 
            {
                  ///
            //missing brace
            }
          }
     }
----------
    using Level1.Level2;
    namespace AnotherNS
    {
       //missing class!
       public class MyClass()
       {
         public mainfunction()
         {
           MyObject myoj1 = new MyObject(1);
           //call method from instance not as static
           System.Messaging.MessageQueue SomeQueue = myoj1.FunctionA();
           
           //I don't even know what this is supposed to do....
           //myoj1 .FunctionA(SomeQueue );
         }
       }
     }
