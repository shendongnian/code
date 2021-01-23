    string s = File.ReadAllText(pathToTown).Trim();
    string[] customersUnparsed = s.Split(new[] { Environment.NewLine + Environment.NewLine },
        StringSplitOptions.RemoveEmptyEntries);
    string[][] customers = Array.ConvertAll(customersUnparsed,
        c => c.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
