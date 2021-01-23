    public bool ValidateLength(string input, int count)
    {
        string pattern = @"^[a-zA-Z]{0," + count.ToString() + "}$";
        return Regex.IsMatch(input,regFormat);
    }
