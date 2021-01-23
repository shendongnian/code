    string lines[] = data.split(Environment.NewLine);
    using(StreamWriter sw = new StreamWriter(File.OpenWrite("c:\csv.txt"))
    {
        for(int i = 0; i < lines.Length; i++)
        {
            sw.WriteLine(lines[i]);
        }
    }
