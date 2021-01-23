    IDictionary<BPLevel, Int32> stats = context
      .Persons
      .Select(x => new { PersonId = x.Person.Id, BPDiastolic = x.BPDiastolic, BPSystolic = x.BPSystolic })
      .GroupBy(p => ... // Test which returns a BPLevel)
      .ToDictionary(g => g.Key, g => g.Count());
