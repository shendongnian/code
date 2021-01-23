    var searchTerms = SearchString.ToLower().Split(null);
    var term = searchTerms[0];
    var results = from e in entities.Employees
                  where (e.FirstName.Contains(term) 
                      || e.LastName.Contains(term) 
                      || e.Roles.Select(r => r.Name).Any(n => n.Contains(term)))
                  select e;
    if (searchTerms.Length > 1)
    {
        for (int i = 1; i < searchTerms.Length; i++)
        {
            var tempTerm = searchTerms[i];
            results = from e in results
                      where (e.FirstName.Contains(tempTerm) 
                          || e.LastName.Contains(tempTerm) 
                          || e.Roles.Select(r => r.Name).Any(n => n.Contains(tempTerm)))
                      select e;
        }
    }
