    var identifiers = new Dictionary<string, string>();
    int i = 0;
    var input = "FGS1=(B+A*10)+A*10+(C*10.5)";
    Regex r = new Regex("([A-Z][A-Z\\d]*)");
    bool f = false;
    
    MatchEvaluator me = delegate(Match m)
    {
        var variableName = m.ToString();
                
        if(identifiers.ContainsKey(variableName)){
            return identifiers[variableName];
        }
        else {
            i++;
            var newVariableName = "i" + i.ToString();
            identifiers[variableName] = newVariableName;
            return newVariableName;
        }
    };
    
    input = r.Replace(input, me);
    Console.WriteLine(input);
