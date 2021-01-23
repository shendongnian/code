    Dictionary<string, string> replacements = new Dictionary<string, string>()
    {
        { "DRIVE", "DR" }
    };
    
    string[] tokens = originalAddress.Split(new char[] { ' ', '\t' });
    StringBuilder normalized = new StringBuilder();
    
    foreach (string t in tokens)
    {
        string rep;
        bool found = replacements.TryGetValue(t.ToUpper(), out rep);
    
        if (found)
        {
            normalized.Append(rep);
        }
        else
        {
            normalized.Append(t);
        }
        normalized.Append(' ');
    }
    
    // normalized.ToString() contains the normalized address
        
