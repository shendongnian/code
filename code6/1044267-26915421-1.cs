    public bool IsValid(string value)
    {
        long temp;
        return string.IsNullOrEmpty(value) || (value.Length == 10 && long.TryParse(string, out temp));
    }
