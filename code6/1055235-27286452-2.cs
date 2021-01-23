    int maxLines = 10,000;
    int numLines = 0;
    int fileNumber = 0;
    var writer = File.CreateText("list" + fileNumber + ".txt");
    foreach (var line in File.ReadLines("sort.txt"))
    {
        writer.WriteLine(line);
        ++numLines;
        if (numLines == maxLines)
        {
            writer.Close();
            numLines = 0;
            ++fileNumber;
            writer = File.Create("list" + fileNumber + ".txt");
        }
    }
    writer.Close();
