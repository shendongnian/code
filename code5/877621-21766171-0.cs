    GrammarBuilder gb = new GrammarBuilder();
    Choices letters = new Choices();
    letters.add(new string[] {"A", "B", "C", "D", ...});
    gb.append(letters);
    Grammer grammar(gb); // this grammar is then be used and should only support the specific subset as defined above.
