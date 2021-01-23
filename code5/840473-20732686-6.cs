    using System.IO;
    string filename = "C:\\C#\\maplist.txt"; // please put the text file path.
    string filename2 = "C:\\C#\\zemaplist.txt";
    string map;
    
    StreamWriter sw = new StreamWriter(filename2);
    List<string> maps = new List<string> { };
    List<string> maps2 = new List<string> { };
    String [] allLines =  File.ReadAllLines(filename);
    foreach(String line in allLines)
    {
       maps.Add(line.Split(',')[0].Trim());
       maps2.Add(line.Split(',')[1].Trim());
    }
    
    
    for (int i = 0; i < maps.Count; i++)
    {
        Console.WriteLine(maps[i]);
        sw.WriteLine(maps[i]);
    }
    sw.Close();
