    string ToLegalFileName(string s)
    {
        var invalidChars = new HashSet<char>(Path.GetInvalidFileNameChars());
        return String.Join("", s.Select(c => invalidChars.Contains(c) ? '_' : c));
    }
