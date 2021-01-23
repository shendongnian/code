    static void Main(string[] args)
    {
        string path = @"C:\datafile.txt";
        string [] allLines = File.ReadAllLines(path);
        List<string> newlines = new List<string>();
       
       foreach (string line in allLines)
       {
           if (line.Contains("test69.com") || line.Contains("http://test69.com") || line.Contains("man.test"))
           {
           }
           else
           {
               newlines.Add(line);                 
           }
       }    
       File.WriteAllLines(path, newlines.ToArray());     
    }
