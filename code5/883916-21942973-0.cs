        var itemsToBePlaceInCollection 
            = Items.Select((itm, index) => new ItemEx(itm) { RowNumber = index + 1; })
                   .ToList();
                   .ForEach(itmEx => Items2.Add( itmEx ));   // Add into the observable collection at this point
  
