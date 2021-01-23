    namespace ExtensionMethods
    {
      public static class MyExtensions
      {
        // I DONOT KNOW YOUR OBJECT TYPE I JUST HAVE USED A DUMMY THING; YOU CAN REPLACE IT!!!!
        public static string ToString(this MyType myClass, bool param)
        {
              if (param)
              {
                 return string.Format(myClass.FIO);
              }
                 return string.Format(myClass.Address);
         }
       }   
    }
