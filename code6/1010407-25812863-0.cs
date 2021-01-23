    StringBuilder allEntries = new StringBuilder();
    foreach (DictionaryEntry DE in Info)
        {
            allEntries += DE.Key +DE.Value; 
        }
     label4.Text = allEntries;
