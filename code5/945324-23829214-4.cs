    var result = equipment
        		.GroupBy( e => e.Id2 )
        		.Select( e => e.OrderBy( e1 => e1.Version1 )
                                 .ThenBy( e2 => e2.Version2 )
                                 .Last() )
                .Select(e => new { 
							Id2 = e.Id2, 
							Version1 = e.Version1, 
							Version2 = e.Version2, 
							Date = history.Where(h => h.ParentId == e.Id2).OrderBy(h => h.Date).Last().Date 
							} 
				);
