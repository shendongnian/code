    private static Dictionary<string, Dictionary<string, int>> ConsolidateRecords(List<TextFileInfo> allTextFileInfo)
    {
        Dictionary<string, Dictionary<string, int>> consolidatedInfo = new Dictionary<string, Dictionary<string, int>>();
        foreach (TextFileInfo ti in allTextFileInfo)
        {
            string key = ti.code1 + ti.code2;
            Dictionary<string, int> allItems = null;
            if (!consolidatedInfo.ContainsKey(key))
                consolidatedInfo.Add(key, new Dictionary<string, int>());
            allItems = consolidatedInfo[key];
            foreach (string code in ti.itemInfo.Keys)
            {
                int quantity = ti.itemInfo[code];
                if (allItems.ContainsKey(code))
                    allItems[code] += quantity;
                else
                    allItems.Add(code, quantity);
            }
        }
        return consolidatedInfo;
    }
