    private Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
    
    private void FillDictionary()
    {
        if (this.dic.Count == 0)
        {
            XmlTextReader reader = new XmlTextReader("browscap.xml");
    
            while (reader.Read())
            {
                if (reader.Name == "browscapitem")
                {
                    string pattern = reader.GetAttribute("name");
                    if (pattern != null)
                    {
                        if (!this.dic.ContainsKey(pattern))
                        {
                            Dictionary<string, string> properties = new Dictionary<string, string>();
                            while (reader.Read())
                            {
                                if (reader.Name == "browscapitem")
                                {
                                    break;
                                }
                                if (reader.GetAttribute("name") != null)
                                {
                                    properties.Add(reader.GetAttribute("name").ToLower(), reader.GetAttribute("value"));
                                }
                            }
                            this.dic.Add(pattern, properties);
                        }
                    }
                }
            }
        }
    }
