    public string GetContents()
    {
        var sb = new StringBuilder();        
        foreach (KeyValuePair<string, int> item in dictionary) {
            sb.AppendLine(string.Format("{0}: {1}", item.Key, item.Value));
        }
        return sb.ToString();
    }
