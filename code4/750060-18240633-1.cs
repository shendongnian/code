    string ToLegalFileName(string s)
    {
        var illegalChars = new HashSet<char>(Path.GetInvalidFileNameChars());
        return String.Join("", s.Select(c => illegalChars.Contains(c) ? '_' : c));
    }
