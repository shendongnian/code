     Choices clist = new Choices();
     clist.Add(new string[] { "Is it working", "Write" });
     GrammarBuilder bl = new GrammarBuilder(clist);
     bl.appendDictation();
     Grammar gr = new Grammar(bl);
