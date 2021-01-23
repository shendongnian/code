    public static string GetAssumeLocation(string connectionString)
    {
        const string assumeLocation = "<Assume_Location>";
        var builder1 = new DbConnectionStringBuilder();
        builder1.ConnectionString = connectionString;
        object extended;
        if (builder1.TryGetValue("Extended Properties", out extended) && extended is string)
        {
            var builder2 = new DbConnectionStringBuilder();
            builder2.ConnectionString = (string)extended;
            foreach (KeyValuePair<string, object> kv in builder2)
            {
                var value = kv.Value as string;
                if (value != null && value.StartsWith(assumeLocation))
                {
                    return Path.GetExtension(value.Substring(assumeLocation.Length));
                }
            }
        }
        return null;
    }
