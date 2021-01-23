    String[] lines = System.IO.File.ReadAllLines(fileName);
    String[] linesArr;
    List<String[]> MultiArr = new List<String[]>();
    foreach (string line in lines)
    {
        if (line.Contains("EFIX"))
        {
        linesArr = line.Split(delimiterChars);
        MultiArr.Add(linesArr);
        Console.WriteLine(fixationsData[i]);
        }
     } 
