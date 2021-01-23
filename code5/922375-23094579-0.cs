    string s = File.ReadAllText(pathToTown);
    string[] customersUnparsed = s.Split(new[] { Environment.NewLine + Environment.NewLine },
        StringSplitOptions.RemoveEmptyEntries);
    string[][] customers = Array.ConvertAll(customersUnparsed,
        c => s.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
