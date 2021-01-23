    static class Extensions {
 
      public static TimesDo( this int x, Action action) {
          for (int i = 0; i < x; i++) action.Invoke();   
      }
    } 
