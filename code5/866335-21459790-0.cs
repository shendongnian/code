    var newline = Encoding.ASCII.GetBytes(Environment.NewLine);
    var files = Directory.GetFiles(filepath);
    try
    {
        using (var writer = File.Open(Path.Combine(filepath, "result.txt"), FileMode.Create))
            foreach (var text in files.Select(File.ReadAllBytes))
            {
                writer.Write(text, 0, text.Length);
                writer.Write(newline, 0, newline.Length);
            }
    }
    catch (IOException)
    {
        // File might be used by different process or you have insufficient permissions
    }
