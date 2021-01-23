    if (wType == "Riconda")
    {
        return dbContext.data_LookupValues
           .Where(w => w.Category == "WLoc")
           .OrderBy(w => w.SortId)
           .Select(a => new WportType {
               Key = a.Key,
               Value = a.Value
           }); // or use something like FirstOrDefault() here
    }
    else 
    {
        return new List<WportType> {
             new WportType { Key = "", Value = "" }
        };
    }
