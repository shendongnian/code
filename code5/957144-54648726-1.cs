    private void UpdateEntryAttributes(DirectoryEntry entry, Dictionary<string, string> attributes)
    {
        foreach (KeyValuePair<string, string> attribute in attributes)
        {
        entry.Properties[attribute.Key].Value = attribute.Value;
    
        if (attribute.Value == "")
        {
            entry.Properties[attribute.Key].Clear();
        }
        else if (!string.IsNullOrEmpty(attribute.Value))
        {
            entry.Properties[attribute.Key].Value = attribute.Value;
        }
    }
