    Regex pattern = new Regex(@"\(([A-Z]*)\)");
    for (var line in File.ReadLines(@"C:\MyDocuments\TickerList.txt")) {
        Match match = pattern.Match(line);
        if (match.Success) {
            Console.WriteLine(match.Groups[1].Value);
            Console.ReadLine();
        }
    }
