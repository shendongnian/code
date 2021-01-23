    private static bool IsValidColorString(string input)
    {
        if (String.IsNullOrEmpty(input))
            return false;
        string[] parts = input.Split(',');
        if (parts.Length != 3)
            return false;
        foreach (string part in parts)
        {
            int val;
            if (!int.TryParse(part, out val) || val < 0 || val > 255)
                return false;
        }
        return true;
    }
