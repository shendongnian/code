    var policyKeysToDelete = policiesToDelete
        .Select(r => new {r.PolicyId, r.GroupId})
        .ToList();
    
    // List of values types, which can be translated to SQL
    var policyIds = policyKeysToDelete.Select(x => x.PolicyId).ToList();
    var groupIds = policyKeysToDelete.Select(x => x.GroupId).ToList();
    
    var objectsToDelete = storageContext.MonitoringRelations
    	// Do the part that we can do in the database, which is select the records
        // which have an corresponding PolicyId or GroupId
    	.Where(x => policyIds.Contains(x.PolicyId) || groupIds.Contains(x.GroupId))
    	// Use this method to indicate that whatever follows after should not be
        // translated to SQL
    	.AsEnumerable()
    	// Do the full check in-memory
    	.Where(x => policyKeysToDelete
            .Any(y => x.PolicyId == y.PolicyId && x.GroupId == y.GroupId)
        )
    	.ToList();
