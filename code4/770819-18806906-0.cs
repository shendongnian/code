    string filePath = @"C:\Users\Matt\Desktop\Eve Spread Sheet\Auto-Manufacture.csv";
    StreamReader sr = new StreamReader(filePath);
    var lines = new List<string[]>();
    int Row = 0;
    while (!sr.EndOfStream)
    {
        string[] Line = sr.ReadLine().Split(',');
        lines.Add(Line);
        Row++;
        Console.WriteLine(Row);
    }
    var data = lines.ToArray();
