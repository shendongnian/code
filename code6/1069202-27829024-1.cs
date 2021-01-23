    private static string GetColumnName(string cellReference)
    {
        if (cellReference == null)
            return null;
        return Regex.Replace(cellReference, "[0-9]", "");
    }
