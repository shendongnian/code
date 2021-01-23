    public static class ConsoleHelper
    {
      static bool isCreated;
    
      [System.Runtime.InteropServices.DllImport("kernel32.dll")]
      private static extern bool AllocConsole();
    
      public static void PrepareConsole()
      {
        if (isCreated) return;
    
        AllocConsole();
        isCreated = true;
      }
    }
