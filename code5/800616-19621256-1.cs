    public static class ExceptionRegions
    {
      public static int Internet = 0xA;
      public static int FileSystem = 0xB;
    }
    public class InternetConnectionException : Exception
    {
      public InternetConnectionException () : base("No internet connection available") { }
    }
    
    public class FileSystemAccessException : Exception
    {
      public FileSystemAccessException () : base("Access to specified path caused an error") { }
    }
    public static class ExceptionFactory
    {
      public static void RaiseException(int code)
      {
        switch(code)
        {
          case ExceptionRegions.Internet : throw new InternetConnectionException();
          ...
          ...
        }
      }
    }
