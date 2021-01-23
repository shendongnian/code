    var lines = System.IO.File.ReadAllLines(@"inputfile.txt");
    foreach (var line in lines)
    {
        var wordsInLine = SplitCSV(line);
        // do whatever you want with the result...
    }
