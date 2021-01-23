    var res = list.Select(x => new 
                            {
                                Person = x,
                                Date = x.Start.Date,
                                Time = x.Start.TimeOfDay
                            })
                    .GroupBy(x => x.Date)
                    .Select(personGroupByDate => new 
                    {
                        Date = personGroupByDate.Key,
                        Persons = personGroupByDate
                            .Select(x => x.Person)
                            .GroupBy(x => x.Time)
                            .Select(person => new 
                            {
                                FirstName = person.FirstName,
                                LastName = person.LastName
                            }).ToList()
                    }).ToList()
