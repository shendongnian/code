    var dramasByPerson = ctx.Dramas.Where(d => d.DateHappened >= startDate)
      .Select(d => new { d.PersonId, d.Id, d.DramaType })
      .ToLookup(d => d.PersonId);
    var predicate = dramasByPerson.Select(o => o.Key)
      .Aggregate(
        PredicateBuilder.False<Person>(),
        (current, personId) => current.Or(o => o.PersonId == personId)
      );
    var dictPeople = ctx.People.Where(predicate)
      .Select(o => new { o.PersonId, o.LastName, o.FirstName })
      .ToDictionary(o => o.PersonId);
    var people = dramasByPerson.Select(o => new {
      LastName = people[o.Key].LastName,
      FirstName = people[o.Key].FirstName,
      Dramas = o.Select(d => new { d.Id, d.DramaType })
    });
      
