    String input = @"sddkjasd""fhadslkfhdskljfahskjff""shkdfjhfkhafklj""NamespaceA.NamespaceB.NamespaceC.ClassnameA""swenbfjiwguzl""lgvfdu""eQVFZEIW""NamespaceA.NamespaceB.NamespaceC.ClassnameB""VDTZEvwqdtzevdzgi";
     
    Regex rgx = new Regex(@"NamespaceA[^""]*?\.([^.""]*)""");
     
    foreach (Match m in rgx.Matches(input))
    Console.WriteLine(m.Groups[1].Value);
     
    }
