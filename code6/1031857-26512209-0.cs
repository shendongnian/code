    public ArrayList GetFileLines(string fileName)
    {
        var lines = new ArrayList();
        using (var rdr = new StreamReader(fileName))
        {
            string line;
            while ((line = rdr.ReadLine()) != null)
                lines.Add(line);
        }
        return lines;
    }
