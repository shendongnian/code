    using System.Text.RegularExpressions;
    ...
    public bool IsValidPhone(string input)
    {
        return Regex.IsMatch(input, @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$");
    }
