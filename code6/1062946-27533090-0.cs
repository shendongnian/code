    // This should preferably be called just once but 
    // would need to be called whenever the list changes
    var checkOutListLookup = itemCheckoutList.ToLookup(ic => ic.ItemID);
    
    // and this can be called as needed.
    var results = itemList.Where(i => !checkOutListLookup.Contains(i.ItemID) ||
                                      checkOutListLookup[i.ItemID].IsComplete);
  
