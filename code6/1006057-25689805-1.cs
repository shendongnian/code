    IDictionary<BPLevel, Int32> stats = context
      .Persons
      .Select(x => new { PersonId = x.Person.Id, BPDiastolic = x.BPDiastolic, BPSystolic = x.BPSystolic })
      .AsEnumerable()  // I'm not completely familiar with Entity Framework, so this line may be necessary to force evaluation to continue in-memory from this point forward
      .GroupBy(p => ... // Test which returns a BPLevel)
      .ToDictionary(g => g.Key, g => g.Count());
