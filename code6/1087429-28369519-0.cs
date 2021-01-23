    GrammarBuilder builder = new GrammarBuilder();
    Choices choice = new Choices (new string[] {"Open", "Close"});
    builder.Append(choice);
    builder.Append("Firefox");
    Grammar grammar = new Grammar(builder);
