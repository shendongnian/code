    private static const bool UsingProduction = false; // or true
    public static string GetDatabaseName(string table)
    {
        return UsingProduction ? table : table + "_backup";
    }
