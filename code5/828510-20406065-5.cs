    string PathAddBackslash(string path)
    {
        // They're always one character but EndsWith is shorter than
        // array style access to last path character. Change this
        // if performance are a (measured) issue.
        string separator1 = Path.DirectorySeparatorChar.ToString();
        string separator2 = Path.AltDirectorySeparatorChar.ToString();
        // White spaces are always ignored (both heading and trailing)
        path = path.Trim();
        // Argument is always a directory name then if there is one
        // of allowed separators then I have nothing to do.
        if (path.EndsWith(separator1) || path.EndsWith(separator2))
            return path;
    
        // If there is the "alt" separator then I add a trailing one.
        if (path.Contains(separator2))
            return path + separator2;
    
        // If there is not an "alt" separator I add a "normal" one.
        // It means path may be with normal one or it has not any separator
        // (for example if it's just a directory name). In this case I
        // default to normal as users expect.
        return path + separator1;
    }
