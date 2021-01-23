    Choices colors = new Choices();
    colors.Add(new string[] {"red", "green", "blue"});
    
    GrammarBuilder gb = new GrammarBuilder();
    gb.Append(colors);
    
    // Create the Grammar instance.
    Grammar g = new Grammar(gb);
