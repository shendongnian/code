    // Parse the file
    var indexes = new List<long>();
    using (var fs = File.OpenRead("text.txt"))
    {
        indexes.Add(fs.Position);
        int chr;
        while ((chr = fs.ReadByte()) != -1)
        {
            if (chr == '\n')
            {                        
                indexes.Add(fs.Position);
            }
        }
    }
    int minLine = 21;
    int maxLine = 40;
    // Read the line
    using (var fs = File.OpenRead("text.txt"))
    {
        for(int i = minLine ; i <= maxLine ; i++)
        {
            fs.Position = indexes[ i ];
            using (var sr = new StreamReader(fs))
                Console.WriteLine(sr.ReadLine());
    }
