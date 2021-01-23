	var filtered = 
	     dataContext.T.Where(s => concatenatedKeys.Contains(
	                                             s.AnotherEntity.Column0 ?? string.Empty + 
	                                             "~" + 
	                                             s.AnotherEntity.Column1));
