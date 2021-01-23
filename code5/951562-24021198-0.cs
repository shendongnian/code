    var identities = personIdentity.AsEnumerable();
    var persons = person.AsEnumerable();
    var query = identities.Zip(persons, (pi, p) => new 
                                                   { 
                                                       PersonKey = pi.Field<string>("PersonKey"),
                                                       PersonNumber = p.Field<string>("PersonNumber"),
                                                       FullName = p.Field<string>("FullName") 
                                                   })
                          .ToList();
