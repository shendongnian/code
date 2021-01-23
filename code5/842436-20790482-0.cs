        using (var sr = new StreamReader(fileToRead))
        using (var sw = new StreamWriter(fileToWrite, true))
        {
            if (sw.BaseStream.Position == 0)
                sw.WriteLine("bla bla...");  // Only write header in a new empty file.
            var count = 1;
