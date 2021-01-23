        string[] lines = File.ReadAllLines(@"c:\test.txt");
        string[] newLines = lines.Select(l =>
        {
            if (!string.IsNullOrEmpty(l)) // keep the empty rows
            {
                return l.Remove(l.LastIndexOf(' ')).TrimEnd();
            }
            return l;
        }).ToArray();
        File.WriteAllLines(@"c:\newtest.txt", newLines);
