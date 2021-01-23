    Dictionary<string, string> replacements = new Dictionary<string, string>()
    {
        {"ACFT", "AIRCRAFT"},
        {"FT", "FEET"},
    };
    
    foreach(string s in replacements.Keys)
    {
        var pattern = "\b" + s + "\b"; // match on word boundaries
        inputBox.Text = Regex.Replace(inputBox.Text, pattern, replacements[s]);
    }
