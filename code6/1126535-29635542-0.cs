    static void Main(string[] args)
    {
        string path = @"c:\temp\test.txt";
        string enpath = @"c:\temp\entest.txt";
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < 72; i++)
        {
            var uri = new Uri(lines[i], UriKind.Absolute);
            var escaped = uri.GetComponents(UriComponents.AbsoluteUri, UriFormat.UriEscaped);
            Console.WriteLine(escaped);
            System.IO.File.AppendAllText(enpath, escaped + Environment.NewLine, Encoding.ASCII);
        }
        Console.ReadLine();
    }
