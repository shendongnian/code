    foreach(var sort in sorting)
    {
        bool descending = sort.By == "desc";
        switch (sort.Sort)
        {
            case "forename":
                query = query.AddOrdering(o => o.Forename, descending);
                break;
            case "surname":
                query = query.AddOrdering(o => o.Surname, descending);
                break;
        }
    }
