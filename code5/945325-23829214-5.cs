    var result = history
        		.GroupBy( h => h.IdParent )
        		.Select( h => h.OrderBy( h1 => h1.Version1 )
                                 .ThenBy( h2 => h2.Version2 )
                                 .Last() )
                .Select(h => new { 
							Id2 = h.IdParent, 
							Version1 = h.Version1, 
							Version2 = h.Version2, 
							Date = h.Date 
							} 
				);
