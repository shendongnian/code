    using (var reader = new System.IO.StreamReader(@"C:\yourfile.txt"))
    {
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line.StartsWith("math_"))
            {
                // do something
            }
        }
        reader.Close();
    }
