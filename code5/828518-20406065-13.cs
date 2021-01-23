    string PathAddBackslash(string path)
    {
        if (path == null)
            throw new ArgumentNullException(nameof(path));
        path = path.TrimEnd();
        if (PathEndsWithDirectorySeparator())
            return path;
    
        return path + GetDirectorySeparatorUsedInPath();
        bool PathEndsWithDirectorySeparator()
        {
            char lastChar = path.Last();
            return lastChar == Path.DirectorySeparatorChar
                || lastChar == Path.AltDirectorySeparatorChar;
        }
        char GetDirectorySeparatorUsedInPath()
        {
            if (path.Contains(Path.DirectorySeparatorChar))
                return Path.DirectorySeparatorChar;
        
            return Path.AltDirectorySeparatorChar;
        }
    }
