    using System.Linq.Dynamic;
    //..
    if (parameters[1] == "ascending" || parameters[1] == "descending")
    {  
        return entities.AsQueryable()
                       .OrderBy(string.Format("{0} {1}", parameters[0], parameters[1]))
    }
    else
    {
        return entities;
    }
