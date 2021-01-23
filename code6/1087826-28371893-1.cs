    #if test
        internal class SomeClass
        {
          public void SomeMethod(){}
        }
    #endif
    
    and :
    public static void main()
    {
    #if test
          var someClass= new SomeClass();
          someClass.SomeMethod();
    #endif
    }
  
