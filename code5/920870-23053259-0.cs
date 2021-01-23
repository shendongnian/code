    var result = TruckAllocations
                    .Where(ta => !string.IsNullOrEmpty(ta.Truck.Name)
                    .GroupBy(ta => ta.UserId)
                    //take the first element of each group, which will be the one with the max CreatedOn date
                    .Select(g=> g.OrderByDescending(m => m.CreatedOn).First())
                    .Select(m => new {
                       Key = m.TruckAllocationId, 
                       Truck = m.TruckId, 
                       User = m.UserId, 
                       Date = m.CreatedOn  
                    });  
   
