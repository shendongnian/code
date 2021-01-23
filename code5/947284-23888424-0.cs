    string[] lines = System.IO.File.ReadAllLines(@"textfile.txt");
    string result[][];
    
    foreach (string line in lines)
    {
        string[] splitedLine = line.Split(',');
        result.Add(splitedLine);
    }
