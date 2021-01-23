    internal class SomeClass
    {
       private static SomeClass singleton;
       private SomeClass(){}  //yes: private constructor
       public static SomeClass GetInstance()
       {
            return singleton ?? new SomeClass();
       }
        public int SomeProperty {get;set;}
        public void SomeMethod()
        {
            //do something
        }
     }
