    Dictionary<string, string> placeholders = new Dictionary<string, string>();
    placeholders.Add("<#= UserName #>", "deepak");
    placeholders.Add("<#= Address #>", "foo address");
    placeholders.Add("<#= City #>", "foo city");
    placeholders.Add("<#= State #>", "foo state");
    placeholders.Add("<#= Zip #>", "foo zip");
  
    string htmlTemplate ="... etc.";
    foreach (KeyValuePair<string, string> kvp in placeholders)
    {
         htmlTemplate = htmlTemplate.Replace(kvp.Key, kvp.Value);
    }
