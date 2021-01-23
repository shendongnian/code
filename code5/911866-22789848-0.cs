    string[] lines = System.IO.File.ReadAllLines("File");
    foreach (var line in lines)
    {
         string[] fields = line.Split('#');
    }
