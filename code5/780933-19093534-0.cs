    ...
    local = rdr.IsDBNull(1) ? 0 : Parse(rdr.GetString(1)).GetValueOrDefault(0),
    ...
    static int? Parse(string value)
    {
        int result;
        if (int.TryParse(value, out result))
        {
            return result;
        }
        return null;
    }
