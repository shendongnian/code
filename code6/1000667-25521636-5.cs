    public async Task WriteAsync(string data)
    {
        var buffer = Encoding.ASCII.GetBytes(data);
        using (var fs = new FileStream(@"File", FileMode.OpenOrCreate, 
            FileAccess.Write, FileShare.None, buffer.Length, true)
        {
             await fs.WriteAsync(buffer, 0, buffer.Length);
        }
    }
