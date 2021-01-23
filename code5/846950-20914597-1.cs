    var replacements = new Dictionary<string, string>();
    replacements.Add("%FirstName%", "Bat");
    replacements.Add("%LastName%", "Man");
    replacements.Add("%currentprice%", "$49.99");
    replacements.Add("%Service%", "Crime Solving");
    
    
    var content = string.Empty;
    using(var streamReader = new StreamReader(@"C:\EmailTemplate.txt"))
    {
    	content = streamReader.ReadToEnd();
    }
    
    content.Dump("Template before Variable Replacement");
    
    foreach(var key in replacements.Keys)
    {
    	content = content.Replace(key, replacements[key]);
    }
    
    content.Dump("Template After Variable Replacement");
