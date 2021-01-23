    private static void AddToFileList(JObject jo, List<string> list, string prefix)
    {
        foreach (var kvp in jo)
        {
            if (kvp.Key == "list_of_files")
            {
                foreach (string name in (JArray)kvp.Value)
                {
                    list.Add(prefix + name);
                }
            }
            else
            {
                JObject dir = (JObject)kvp.Value;
                if (dir.Count == 0)
                {
                    list.Add(prefix + kvp.Key);
                }
                else
                {
                    AddToFileList(dir, list, prefix + kvp.Key + "/");
                }
            }
        }
    }
