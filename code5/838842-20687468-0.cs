    public bool IsTheStringIWant(string s)
    {
        Regex regex = new Regex("%.*\\^.*\\$.*\\^.*\\^\\?.*;.*=.*\\?%");
        return regex.IsMatch(s);
    }
