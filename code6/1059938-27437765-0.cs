    public static string GetDataAddedTemplate(string htmlTemplate, ListDictionary replacements)
    {
        foreach (DictionaryEntry item in replacements)
        {
            // Use the string returned by Replace method
            htmlTemplate = htmlTemplate.Replace(item.Key.ToString().ToLower(), item.Value.ToString());
        }
        return htmlTemplate;
    }
