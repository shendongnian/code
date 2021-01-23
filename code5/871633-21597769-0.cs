    string ReplaceSomeHyphens(string input)
    {
        string result = Regex.Replace(input, @"(\D)-", "${1} ");
        result = Regex.Replace(input, @"-(\D)", " ${1}");
        return result;
    }
