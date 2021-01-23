    public string EscapePathSeparators(string path)
    {
    
        StringBuilder sb = new StringBuilder();
        foreach (var segment in path.Split(new char[]{ ‘\’ }, StringSplitOption.RemoveEmptyEntries))
        {
            sb.Append("\\" + segment);
        }
        return sb.ToString().Substring(2);
    }
