    namespace someSpace
    {
        public class EmptyClass : System.Web.UI.Page
        {
            public int someInt;
        }
    }
    namespace someSpace
    {
         public class referencingClass : System.Web.UI.UserControl
         {
             public void someMethod()
             {
                 EmptyClass anEmptyClass = new EmptyClass();
    
                 int someInt = anEmptyClass.someInt;
             }
         }
    }
