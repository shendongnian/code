    private string IfItIsPicture(string URI_obrazku)
    {
        var knownExtensions = new [] { ".jpg",".png",".bmp", "..."};
        var extension = Path.GetExtension(URI_obrazku);
        if (knownExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
        {
            // ... some code
        }
        return "someString";
    }
