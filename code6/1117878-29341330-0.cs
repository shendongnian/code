    Choices inputs = new Choices();
    inputs.Add(new string[] {"press 3", "press 4"});
    
    GrammarBuilder gb = new GrammarBuilder();
    gb.Append(inputs);
    Grammar g = new Grammar(gb);
    _recognizer.LoadGrammar(g);
