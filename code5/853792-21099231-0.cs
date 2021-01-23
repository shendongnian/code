        if (wType == "Riconda")
        {
            return dbContext.data_LookupValues
               .Where(w => w.Category == "WLoc")
               .OrderBy(w => w.SortId)
               .Select(a => new WportType
               {
                   Key = a.Key,
                   Value = a.Value
               });
        }
        else 
        {
            return Enumerable.Empty<WportType>();
        }
