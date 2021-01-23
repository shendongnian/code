    public void WriteKCore(string path, string fileName, string content)
    {
        using (var writer = new StreamWriter(Path.Combine(path, fileName), true))
        {
            writer.Write(content);
        }
    }
