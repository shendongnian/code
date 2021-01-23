    string pattern = @"^[1-8][A-Z](0[1-9]|[1-8][0-9]|9[0-8])$";
    Regex regex = new Regex(pattern);
    string[] valid = { "1A01", "8Z98" };
    bool allMatch = valid.All(regex.IsMatch);
    string[] invalid = { "0A01", "11A01", "1A1", "1A99", "1A00", "101", "1AA01" };
    bool allNotMatch = !invalid.Any(regex.IsMatch);
