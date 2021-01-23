    namespace ExtensionMethods
    {
      public static class MyExtensions
      {
        public static string ToString(this String str, bool param)
        {
              if (param)
              {
                 return string.Format(FIO);
              }
                 return string.Format(Address);
         }
       }   
    }
