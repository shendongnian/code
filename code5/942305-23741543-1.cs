        Dictionary<string, string> eliza = new Dictionary<string, string>();
        var lines = File.ReadAllLines("D:\\eliza.txt");
        foreach (string line in lines)
        {
            var parts = line.Split('=');
            if (parts.Length==2) eliza.Add(parts[0].ToLower(), parts[1]);
        }
        
