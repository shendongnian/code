    const char Delimiter = '|';
    var dt = new DataTable;
    using (var m = File.ReadLines(filePath).GetEnumerator())
    {
        m.MoveNext();
        foreach (var name in m.Current.Split(Delimiter))
        {
            dt.Columns.Add(name);
        }
        while (m.MoveNext())
        {
            dt.Rows.Add(m.Current.Split(Delimiter));
        }
    }
    
