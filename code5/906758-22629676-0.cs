    string[] allLines = File.ReadAllLines(@"C:\\file.csv");
    Random rnd = new Random();
    List<string> randomLines = new List<string>(allLines.Length);
    for(int i = 0; i < allLines.Length ; i++)
    {
        randomLines.Add(allLines[rnd.Next(allLines.Length)]);
    }
