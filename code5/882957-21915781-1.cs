    // Get the machines to process only once by not getting a queryable.
    var machines =
    this.lboxMachines.SelectedItems
                     .Where( machine => machine.Contains(GimaID) )
                     .ToList(); // Don't keep this IQueryable but as a hard list by this call.
    
    // Get *only* the parts to use; using one DB call
    var parts = ProductionEntity.PARTDATAs
                                .Where(part => machines.Contains(part.Machine))
                                .ToList(); 
    
    // Now from the parts get the count based off of the time each hour
    var resultPerHour = 
          Enumerable.Range(0, 24)
                    .Select (hour => new
    		                        {
    		                           Hour = hour,
    	                               Count = parts.Count(part => part.DATETIME >= StartDate.AdHours(hour) && part.DATETIME <= EnDate)
    		                         }); 
