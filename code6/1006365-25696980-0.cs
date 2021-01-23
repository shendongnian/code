    static int FindOption(string options, string name)
    {
        using (var reader = new StringReader(options))
        {
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null) break;
                Match match = Regex.Match(line, @"^\s*(\d+)\s*:\s*(.*)");
                if (match.Success && match.Groups[2].Value.Contains(name))
                {
                    return int.Parse(match.Groups[1].Value);
                }
            }
        }
        return 0;
    }
