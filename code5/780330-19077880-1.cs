    static void WriteToFile(string directory, string name)
    {
        string filename = String.Format(name + ".ini");
        string path = Path.Combine(directory, filename);
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Inserted Text");
        }
    } 
......
    var allFiles = Directory.GetFiles(folder, "*.txt");
    foreach (string file in allFiles)
    {
        var lines = File.ReadAllLines(file);
        foreach (string newfile in lines)
        {
            WriteToFile(folder, newfile);
        }
    }
