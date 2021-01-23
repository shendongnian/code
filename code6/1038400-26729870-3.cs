    string[] search = new string[] {"DOC","PCB"};
    var lines = System.IO.File.ReadAllLines(@"D:\MyFile.txt");
    var result1 = lines.Where(item => !item.Contains(search[0]) && !item.Contains(search[1]));
    StringBuilder sb = new StringBuilder();
    foreach (string line in result1)
    {
        sb.AppendLine(line);
    }
