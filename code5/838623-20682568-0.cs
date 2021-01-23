    var groupResults = new List<Tuple<string, List<string>>>();
    List<string> subLines = null;
    foreach(var line in lines)
    {
        if(line.StartsWith("01"))
        {
            subLines = new List<string>();
            groupResults.Add(Tuple.Create(line, subLines));
        }
        // consider to handle the case where a line begin with 02 with no 01 before
        else if(subLines != null && line.StartsWith("02"))
        {
            subLines.Add(line);
        }
    }
    
