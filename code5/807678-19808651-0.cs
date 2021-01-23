    List<string> placeholders = new List<string>();
    placeholders.Add("<#= UserName #>");
    placeholders.Add("<#= Address #>");
    placeholders.Add("<#= City #>");
    placeholders.Add("<#= State #>");
    placeholders.Add("<#= Zip #>");
    string htmlTemplate ="... etc.";
    foreach(string s in placeholders)
    {
        htmlTemplate = htmlTemplate.Replace(s, somevalue);
    }
