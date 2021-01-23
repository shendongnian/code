    public string BuildFilterString(bool includeAllFiles, params string[] extensions)
    {
        var filters = extensions.Select(ex => string.Format("{0} files (*.{0})|*.{0}", ex)); 
        string result = string.Join("|", filters);
        if (includeAllFiles)
        {
            result += result == string.Empty ? "All files (*.*)|*.*" : "|All files (*.*)|*.*";
        }
        return result;
    }
