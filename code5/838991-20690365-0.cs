    string inputXML = @"
    <
    blahblahblahblahblah>";
    string pattern = @"(?<=\<)\s+"; //match one or more whitespace following a <
    var cleaned = Regex.Replace(inputXML,
                                pattern, 
                                string.Empty,
                                RegexOptions.Multiline)
