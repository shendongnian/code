    var q = db.Continent
              .AsExpandable()
              .Select(c => new 
              {
                  c.ID,
                  c.Name,
                  c.Area,
                  Countries = c.Countries
                      .Where(ct => countryIndepBeforeExpr.Invoke(ct, someDate))
                      .Select(ct => new {ct.ID, ct.Name, ct.IndependenceDate})
    });
