    foreach (var file in Directory.EnumerateFiles(@"c:\", "*.txt", SearchOption.AllDirectories))
    {
        this.pro.Rows.Add(/*filename*/ , GetFirstLine(/*filename*/,2) , ....)
    }
    
    string GetFirstLine(string fileName, int line)
    {
       using (var sr = new StreamReader(fileName)) {
           for (int i = 1; i < line; i++)
              sr.ReadLine();
           return sr.ReadLine();
       }
    }
