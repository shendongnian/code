    char[] seperator = { ' ' };
    String[] explodedString = Results1[index].Key.Split(seperator);
    List<String> Query= new List<string>(TextBox1.Text.Trim().ToLowerInvariant().Split(seperator,StringSplitOptions.RemoveEmptyEntries));
    
    for (int i = 0; i < explodedString.Length; i++)
    {
        if (Query.Contains(explodedString[i].ToLowerInvariant()) == true)
        {
           explodedString[i] = "<strong>" + explodedString[i] + "</strong>"; //changed
        }
    }
    Literal temp = new Literal();
    temp.Text = string.Join(" ", explodedString); //changed 
    TryCurrentWindow[index] = new KeyValuePair<Literal, string>(temp, Results1[index].Value);
 
