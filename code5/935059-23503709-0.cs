    private string TruncatePath(string path)
    {
        if (path == "/")
            return path;
 
        var parts = path.Split(new []{'/'}, StringSplitOptions.RemoveEmptyEntries);
        return String.Format("/{0}/", String.Join("/", parts.Take(2)));
    }
