    string RemoveBetween(string s, char begin, char end)
    {
        Regex regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
        return regex.Replace(s, string.Empty);
    }
    
    string s = "remove only \"railing\" spaces of a string in Java";
    s = RemoveBetween(s, '"', '"');
