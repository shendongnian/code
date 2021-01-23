    foreach (System.Collections.DictionaryEntry entry in areaDictionary)
    {
        MessageBox.Show(entry.Key);
        MessageBox.Show(((NWN2GameArea)entry.Value).Name);
    }
