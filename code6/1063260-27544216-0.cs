    using (var output = new StreamWriter(@"E:\text.txt"))
    {
        foreach(var line1 in File.ReadLines("e:\\1.txt"))
        {
            foreach(var line2 in File.ReadLines("e:\\2.txt"))
            {
                output.WriteLine("{0} {1}", line1, line2);
            }
        }
    }
