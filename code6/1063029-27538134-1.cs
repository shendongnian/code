    IQueryable<EFModel.Inventory> query = GetInventoryView();
     if (searchParameters.GroupByLocation)
            {
    
    var model = query.GroupBy((group => 
                                     new { LocationID = group.LocationID, 
                                           LocationType = group.LocationType, 
                                           ProductID = group.ProductID 
                                         }
                            )
                     .Select(select => 
                     new <returning object>() { 
                         total = select.Sum(total => total.{Amount Property}), 
                         LocationID = select.Key.LocationID, 
                         ...., 
                         //other properties here  
                         }); 
      //do other stuff here 
    
    }
