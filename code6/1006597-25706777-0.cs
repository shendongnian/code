    private static void Main(string[] args)
    {
        var text = File.ReadLines(@"YourFile.txt");
        var lines = ParseList(text);
        using (var file = File.AppendText(@"NewFile.csv"))
        {
            file.Write(String.Join(",", lines));
        }
        Console.ReadLine();
    }
    private static IEnumerable<string> ParseList(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var newline = Regex.Replace(line, @"<.*?>", String.Empty);
            if (newline.StartsWith("^"))
            {
                // change carrot to newline
                newline = Environment.NewLine + newline.Remove(0, 1);
            }
            yield return newline;
        }
    }
