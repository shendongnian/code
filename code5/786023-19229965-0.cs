    using (var fs = new FileStream("test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
    using (var reader = new StreamReader(fs))
    {
        while (true)
        {
            var line = reader.ReadLine();
            if (!String.IsNullOrWhiteSpace(line))
                Console.WriteLine("Line read: " + line);
        }
    }
