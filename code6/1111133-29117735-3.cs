    public static class MethodCallHelper
    {
      public static void Log(Action action)
      {
        try
        {
          Console.WriteLine("Begin " + action.Method.ToString());
          
          action();
        }
        finally
        {
          Console.WriteLine("End " + action.Method.ToString());
        }
      }
    }
