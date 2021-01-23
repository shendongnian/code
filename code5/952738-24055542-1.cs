    bool isSorted = false;
    foreach(var sort in sorting)
    {
        switch(sort.By)
        {
            case "asc":
               switch(sort.Sort)
               {
                   case "forename":
                       if (!isSorted)
                       {
                           query = query .OrderBy(o => o.Forename);
                           isSorted = true;
                       }
                       else
                       {
                           query = ((IOrderedQueryable<Person>)query).ThenBy(o => o.Forename);
                       }
                   ...
               }
            break;
            case "desc":
                   ...
        }
    }
