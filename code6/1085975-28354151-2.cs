    private Dictionary<string, string> GetBrowserProps(string parentId)
    {
        return this.dic[parentId];
    }
    
    public Dictionary<string, string> GetBrowserObject(string uaString)
    {
        this.FillDictionary();
    
        bool found = false;
        string foundKey = "";
    
        foreach (string pattern in this.dic.Keys)
        {
            if (!found)
            {
                found = RecordBrowsers.BrowserPatternMatches(pattern, uaString);
                if (found) { foundKey = pattern; break; }
            }
        }
    
        Dictionary<string, string> browserProps = new Dictionary<string, string>();
        if (foundKey != "")
        {
            browserProps = this.GetBrowserProps(foundKey);
            Dictionary<string, string> current = this.GetBrowserProps(foundKey);
            bool cont = current.ContainsKey("parent");
            while (cont)
            {
                Dictionary<string, string> parent = this.GetBrowserProps(current["parent"]);
                foreach (string s in parent.Keys)
                {
                    if (!browserProps.ContainsKey(s))
                    {
                        browserProps.Add(s, parent[s]);
                    }
                }
                current = parent;
                cont = current.ContainsKey("parent");
            }
        }
    
        return browserProps;
    }
