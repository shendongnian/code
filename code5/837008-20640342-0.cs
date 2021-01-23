    using (var fs = new FileStream(outpuFilePath, FileMode.Append, FileAccess.Write))
    {
        using (var sw = new StreamWriter(fs))
        {
            foreach (var line in File.ReadLines(filepath).Where(line => line.Contains(myXML.searchSTRING)))
            {
                sw.WriteLine(line);
            }
        }
    }
