    private static void SaveToFiles(Dictionary<string, Dictionary<string, int>> consolidatedData)
    {
        foreach (string key in consolidatedData.Keys)
        {
            string filename = key + ".log";
            Dictionary<string, int> items = consolidatedData[key];
            foreach (string code in items.Keys)
            {
                int quantity = items[code];
                File.AppendAllText(filename, code + "\t" + quantity.ToString("D8") + Environment.NewLine);
            }
        }
    }
