    static void MergeFilesForDay(string dir, DateTime date, List<string> files)
    { 
        string file = Path.Combine(dir, date.ToString("yyyyMMdd") + ".csv");
        using(var stream = File.CreateText(file))
        {
            foreach(string fn in files)
                foreach(string line in File.ReadAllLines(fn))
                    stream.WriteLine(line);
        }
    }
