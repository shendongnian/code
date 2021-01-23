    List<string> connectionIds = ...;
    
    if (connectionIds.Any()) {
    	var data = db.Connection
    		.Where(x => connectionIds.Contains(x.ConnectionID))
    		.ToList();
    	foreach (var item in data) {
    		item.Connected = false;
    	}
    	db.SaveChanges();
    }
                        
