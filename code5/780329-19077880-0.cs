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
    string[] allFiles = Directory.GetFiles(folder, "*.txt");
    foreach (string file in allFiles)
    {
        string[] lines = File.ReadAllLines(file);
        foreach (string newfile in lines)
        {
            WriteToFile(folder, newfile);
        }
    }
