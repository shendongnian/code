    private static List<TextFileInfo> LoadFiles()
    {
        string[] files = System.IO.Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath), "*.txt");
        //The inner dictionary contains item code and their quantity. Outer dictionary store the code and their items details
        //Dictionary<string, Dictionary<string, int>> allRecords = new Dictionary<string, Dictionary<string, int>>();
        List<TextFileInfo> allTextFileInfo = new List<TextFileInfo>();
        foreach (string file in files)
        {
            string[] lines = File.ReadAllLines(file);
            TextFileInfo ti = new TextFileInfo();
            string codeLine = lines[0];
            string[] codeParts = codeLine.Split(';');
            ti.code1 = codeParts[0];
            ti.code2 = codeParts[1];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] codeAndAmount = lines[i].Split('\t'); //assuming tab as the separator.
                string code = codeAndAmount[0];
                int quantity = 0;
                if (int.TryParse(codeAndAmount[1], out quantity))
                {
                    if (ti.itemInfo.ContainsKey(code))
                        ti.itemInfo[code] += quantity;
                    else
                        ti.itemInfo.Add(code, quantity);
                }
            }
            allTextFileInfo.Add(ti);
        }
        return allTextFileInfo;
    }
