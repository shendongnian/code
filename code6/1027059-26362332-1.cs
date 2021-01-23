    static void MergeFilesForDay(string dir, DateTime date, List<string> files)
    { 
        string file = Path.Combine(dir, date.ToString("YYYYMMDD") + ".csv");
        using(var stream = File.CreateText(file))
        {
            foreach(string fn in files)
            {
                stream.Write(File.ReadAllText(fn));
            }
        }
    }
