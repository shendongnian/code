    public void get_Unique_Sequence(List<string> name, List<List<string>> nameSequence)
    {
        Hashtable test = new Hashtable();
        test.Add(nameSequence, name);
        foreach (DictionaryEntry entry in test)
        {
            string key = string.Empty;
            foreach (string s in (List<string>)entry.Key)
            {
                key += s + " "; 
            }
            foreach (List<string> list in (List<List<string>>)entry.Value)
            {
                string value = string.Empty;
                foreach (string s in list)
                {
                    value += s + " ";
                }
                Console.WriteLine("{0}: {1}", key, value);
            }
        }
    }
