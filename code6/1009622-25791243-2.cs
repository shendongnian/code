    var listIDsA = collectionA.Select(s => s.Id).Distinct().ToList();
    var listIDsB = collecitonB.Select(s => s.Id).Distinct().ToList();
    var idsToRemove  = listIDsB.Select (s => !listIDsA.Contains(s.Id)).ToList();
    
    var idsToUpdate = listIDsB.Select(s => listIDsA.Contains(s.Id)).ToList();
    var idsToAdd = listIDsA.SelecT(s => !listIDsB.Contains(s.Id)).ToList();
