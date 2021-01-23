    // Example data
    var list = new List<dynamic>{
				new {orderKey = "a", key1 = 1, key2 = 2},
				new {orderKey = "b", key1 = 1, key2 = 2},
				new {orderKey = "c", key1 = 1, key2 = 3},
				new {orderKey = "d", key1 = 1, key2 = 2}
		};
		
    var groupNr = 0; // initial group
	
    var sorted = 
            list
                .OrderBy(i => i.orderKey)
                // Create a new item for each, adding a calculated groupNr:
                .Select((i, nr) => 
                           new { 
                                i.orderKey, 
                                i.key1, 
                                i.key2, 
                                groupNr = (nr == 0 // check if first group
                                               ? 0 // first groupNr must be 0
                                               : (i.key1 == list[nr-1].key1 
                                                    && i.key2 == list[nr-1].key2) 
                                                  ? groupNr 
                                                  : ++groupNr ) 
			})
         // Now just group by the groupNr we have added:
	 .GroupBy(i => i.groupNr);
