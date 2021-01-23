    public static void ApplyColumnFormatting(this System.Data.DataTable table, string column, Action formatDateTime, Action formatNumeric)
    {
        bool foundNonDateTime = false;
        bool foundNonNumeric = false;
        DateTime dt;
        Double num;
        foreach (System.Data.DataRow row in table.Rows)
        {
            string val = row[column] as string;
            // Optionally skip this iteration if the value is not a string, depending on your needs.
            if (val == null)
                continue;
            // Check for non-DateTime, but only if we haven't already ruled it out
            if (!foundNonDateTime && !DateTime.TryParse(val, out dt))
                foundNonDateTime = true;
            // Check for non-Numeric, but only if we haven't already ruled it out
            if (!foundNonNumeric && !Double.TryParse(val, out num))
                foundNonNumeric = true;
            // Leave loop if we've already ruled out both types
            if (foundNonDateTime && foundNonNumeric)
                break;
        }
        if (!foundNonDateTime)
            formatDateTime();
        else if (!foundNonNumeric)
            formatNumeric();
    }
