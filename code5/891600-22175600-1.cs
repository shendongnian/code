    var continents = db.Continents;
    var countries = db.Countries
                      .AsExpandable()
                      .Where(c => countryIndepBeforeExpr.Invoke(c, someDate))
                      .Select(c => new { c.ID, c.Name, c.IndependenceDate });
    var q = continents.GroupJoin(countries,
        continent => continent.ID,
        country => country.ContinentId,
        (continent, countries) => new
        {
            continent.ID,
            continent.Name,
            continent.Area,
            Countries = countries.Select(c => new
            {
                c.ID,
                c.Name,
                c.IndependenceDate
            })
        });
              
