    public async Task WriteAsync(string data)
    {
        using (var sw = new StreamWriter(@"FileLocation")
        {
             await sw.WriteAsync(data);
        }
    }
