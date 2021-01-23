    using System.Runtime.CompilerServices;
    public static String CurrentLocation(
      [CallerFilePath] string file = null,
      [CallerLineNumber] int lineNumber = 0,
      [CallerMemberName] string method = null)
    {
      String location = file;
      if (lineNumber != 0)
      {
        location += "(" + lineNumber.ToString() + ")";
      }
      if (!String.IsNullOrWhiteSpace(method))
      {
        location += ": " + method;
      }
      if (!String.IsNullOrWhiteSpace(location))
      {
        location += ": ";
      }
      return location;
    }
