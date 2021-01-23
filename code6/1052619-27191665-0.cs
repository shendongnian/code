    [Conditional("DEBUG")]
    void Log([CallerMemberName] string memberName = "", [CallerLineNumber] int line = 0)) {
        Debug.WriteLine(memberName);
        Debug.WriteLine(line);
    }
