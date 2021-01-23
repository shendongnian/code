    string names;
    List<string> values;
    using (var stream = new StreamReader("path/to/file.csv"))
    {
        names = stream.ReadLine();
        values = stream.ReadLine().Split(',').ToList();
    }
    values.RemoveAt(9);
    names; // first part of file
    string secondPartOfFile = string.Join(",", values);
