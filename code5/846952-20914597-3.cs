    var content = string.Empty;
    using(var streamReader = new StreamReader(@"C:\EmailTemplate.txt"))
    {
        content = streamReader.ReadToEnd();
    }
    
    var matches = Regex.Matches(content, @"%(.*?)%", RegexOptions.ExplicitCapture);
    
    var extractedReplacementVariables = new List<string>(matches.Count);
    foreach(Match match in matches)
    {
    	extractedReplacementVariables.Add(match.Value);
    }
    
    extractedReplacementVariables.Dump("Extracted KeyReplacements");
    
    //Do your code here to populate these, this part is just to show it still works
    //Modify to meet your needs
    var replacementsWithValues = new Dictionary<string, string>(extractedReplacementVariables.Count);
    for(var i = 0; i < extractedReplacementVariables.Count; i++)
    {
    	replacementsWithValues.Add(extractedReplacementVariables[i], "TestValue" + i);
    }
    
    content.Dump("Template before Variable Replacement");
    
    foreach(var key in replacementsWithValues.Keys)
    {
        content = content.Replace(key, replacementsWithValues[key]);
    }
    
    content.Dump("Template After Variable Replacement");
