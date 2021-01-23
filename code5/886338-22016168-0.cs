      public static class Extension
      {
        public static void Test(this DateTime? dt)
        {
        }
      }
    
      public class Program
      {
        private void Main()
        {
          DateTime? now = DateTime.Now;
          Extension.Test(now); 
          now.Test();  
       }
      }
