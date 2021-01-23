    System.Threading.Timer t = new System.Threading.Timer(End, null, N * 60 * 1000, Timeout.Infinite);
      private static void End(object state)
      {
         // Tell the user and end the program
      }
