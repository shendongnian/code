    var lines = new List<string>();
    using (StreamReader reader = new StreamReader(@"C:\test.txt")) {
        var line = reader.ReadLine();
        while (line != null) {
            lines.Add(line);
            line = reader.ReadLine();
        }
    }
