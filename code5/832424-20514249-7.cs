    public static object DateOrString(string input)
    {
        if (String.IsNullOrWhiteSpace(input))
            return input;
        DateTime parsedDate;
        if (DateTime.TryParse(input, out parsedDate))
            return parsedDate;
        return input;
    }
    ...
    var searchInput = "Field1:val1,Field2:val2,Field3:val3,Field4:2013-12-11T01:00:00";
    var regex = new Regex(@"(?<key>\w*)[:=](?<value>[\w-:]*),?");
    var matches = regex.Matches(searchInput);
    var pairs = from Match match in matches
        select new {
            Key = match.Groups["key"].Value, 
            Value = DateOrString(match.Groups["value"].Value)
        };
