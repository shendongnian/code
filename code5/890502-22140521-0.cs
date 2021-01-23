    string path = @"C:\data.txt";
    string searchKey = "Rel";
    List<string> newlines = new List<string>();
    foreach (var line in File.ReadLines(path))
    {
    if (line.Split(new char[]{' '},
             StringSplitOptions.RemoveEmptyEntries)[1].Contains(searchKey))
    {
    newlines.Add(line);
    }
    }
    File.WriteAllLines(path,newlines.ToArray());
