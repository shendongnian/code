    private void FillM()
    {
       ///...
       
        foreach (KeyValuePair<string, int> item in MenuContent)
        {
            NameList.Add(item.Key);
        }
    }
    
