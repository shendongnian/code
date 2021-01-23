    using (var fs = new FileStream("sort.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        using (var reader = new StreamReader(fs))
        {
            int i = 0;
            while (!reader.EndOfStream && i < max)
            {
                string line = reader.ReadLine();
                if (i > min)
                    outfile.WriteLine(line);
                ++i;
            }
        }
    }
