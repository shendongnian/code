    var originalName = "#123;Firstname Lastname";
    var filteredName = new string(originalName
                                     .Where(c => Char.IsLetter(c) || 
                                                 Char.IsWhiteSpace(c))
                                     .ToArray());
