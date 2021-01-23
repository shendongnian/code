    var tagsList = sourceLists.Select(t => t.TagNo).Distinct().ToList();
    foreach (var tagList in tagsList)
    {
    var terminalList = sourceLists.Where(t => t.TagNo == tagList).Select(t => int.Parse(t.TermNo)).ToList();    
    var result = Enumerable.Range(1, terminalList.Max()).Except(terminalList).ToList();
    }   
                            
