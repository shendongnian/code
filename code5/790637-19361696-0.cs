    var terminalsByTag = sourceLists.GroupBy(x => x.TagNo)
                                    .Select(x => {
                                        TagNo = x.Key,
                                        Terminals = x.Select(t => Int32.Parse(t.TermNo))
                                    });
    var result = Enumerable.Range(1, terminalsByTag.Max(g => g.Terminals.Max()).Except(g => g.Terminals).ToList();
    
                                                          
    
