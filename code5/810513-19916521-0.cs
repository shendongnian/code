      // Create alternatives for female names and add a phrase.
      GrammarBuilder females = new Choices(new string[] { "Anne", "Mary" });
      females.Append("on her");
    
      // Create alternatives for male names and add a phrase.
      GrammarBuilder males = new Choices(new string[] { "James", "Sam" });
      males.Append("on his");
    
      // Create a Choices object that contains an array of alternative
      // GrammarBuilder objects.
      Choices people = new Choices();
      people.Add(new Choices(new GrammarBuilder[] {females, males}));
    
      // Create a Choices object that contains a set of alternative phone types.
      Choices phoneType = new Choices();
      phoneType.Add(new string[] { "cell", "home", "work" });
    
      // Construct the phrase.
      GrammarBuilder gb = new GrammarBuilder();
      gb.Append("call");
      gb.Append(people);
      gb.Append(phoneType);
      gb.Append(new GrammarBuilder("phone"), 0, 1);
