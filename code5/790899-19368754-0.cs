    var concatenatedkeys = keys.Select(m => m[0] + "~" + m[1]).ToList();
    
    var filtered = 
         dataContext.T.Where(s => concatenatedKeys.Contains(
                                                 s.Column0 ?? string.Empty + 
                                                 "~" + 
                                                 s.Column1));
