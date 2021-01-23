    public string GetIdPartValue(string idPart, string test)
    {
        var escIdPart = Regex.Escape(idPart);
        var pattern = string.Format("(?<=[\\{{\\s,]{0}\\s*=\\s*)\\d+", escIdPart);
        var result = default(string);
        var match = Regex.Match(test, pattern, RegexOptions.IgnoreCase);
        if (match.Success)
        {
            result = match.Value;
        }
        return result;
    }
    
    ...
    
    var pid = "{id=2, genderid=5, stateid=4}";
    var id = GetIdPartValue("id", pid); // returns "2"
    var genderid = GetIdPartValue("genderid", pid); // returns "5"
    var stateid = GetIdPartValue("stateid", pid); // returns "4"
