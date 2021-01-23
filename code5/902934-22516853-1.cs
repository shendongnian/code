    [Conditional("DEBUG")]
    void Log(string message, 
          [CallerMemberName] string member = "", 
          [CallerFilePath] string path = "", 
          [CallerLineNumber] int line = 0 ) {
        Debug.WriteLine(string.Format("{0}\t{1}:{3} ({2}) ", 
             message, member, path, line));
    }
