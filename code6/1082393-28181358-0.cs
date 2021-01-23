    class P
    {
      enum E { ABC } 
      static void Main()
      {
         object obj = E.ABC;
         Console.WriteLine(obj.ToString()); // ABC
      }
    }
    
