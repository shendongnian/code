    private static string GetNameContents(ManagementObject queryObj, string propertyName)
    {
        object propertyValue = queryObj[propertyName];
        if (propertyValue == null)
            return String.Empty;
        string propertyString = propertyValue.ToString();
        return propertyString.Length == 0
            ? String.Empty
            : propertyString.Split(new[] { "Name=" }, StringSplitOptions.None).Last().Trim('"');
    }
