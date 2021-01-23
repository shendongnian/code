    using System.IO;
    string[] lines = File.ReadAllLines(@"C:\Users\Public\Test\Text1.txt");
    List<string> newLines = new List<string>();
    
    foreach (string line in lines)
       newLines.Add(line.Replace("\"",""));
    
    File.WriteAllLines("Text2.txt", newLines);
