    private int getNumber(string parentNodeHeader)
    {
        System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(parentNodeHeader, @"\d+");
        return Convert.ToInt32(m.Value);
    }
