    string path1 = @"C:\data1.txt";
    string path2 = @"C:\data2.txt";
    string searchKey = "Rel";
    List<string> newlines = new List<string>();
    foreach (var line in File.ReadLines(path1))
    {
    if (line.Split(new char[]{' '},
             StringSplitOptions.RemoveEmptyEntries)[1].Contains(searchKey))
    {
    newlines.Add(line);
    }
    }
    File.WriteAllLines(path2,newlines.ToArray());
