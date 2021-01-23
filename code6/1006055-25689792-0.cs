    IDictionary<BPLevel, Int32> stats = context
      .Persons
      .Select(x => new { PersonId = x.Person.Id, BPDiastolic = x.BPDiastolic, 
                         BPSystolic = x.BPSystolic, 
                         Classification = GetClassification(BPDiastolic, BPSystolic) })
      .Count( ...
    
    BPLevel GetClassification(int diastolic, int systolic)
    {
        ...
    }
