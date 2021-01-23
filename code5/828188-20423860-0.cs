    ...
    else
    {
        // create a temporary collection for storing new items
        var list = new List<DisplayObjectDates>();
        foreach (var VARIABLE in SortedDatesDays)
        {
             if (...) { ... }
             else
             {
                  var addDisplayObjectDatesYear = new DisplayObjectDates();
                  ...
                  // place it to the new list instead
                  list.Add(addDisplayObjectDatesYear);
             }
         }
         // merge lists
         SortedDatesDays.AddRange(list);
    }
