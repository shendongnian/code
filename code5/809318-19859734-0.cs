    var fileName = Path.GetTempPath();
    List<string> lines = new List<string>();
    for (int i = 0; i <= 20000; i++)
    {                    
       lines.Add("vinod" + i);                   
    }
    File.WriteAllLines(fileName, lines);
