    ClientNames = x.Attendees.Any()
                      ? x.Attendees.Count == 1
                          ? x.Attendees.Select(a => a.Person.CorrespondenceName).FirstOrDefault()
                          : x.Attendees.Count == 2
                              ? string.Join(", ", x.Attendees.OrderBy(a => a.ID).Take(2)
                                                             .Select(a => a.Person.CorrespondenceName).FirstOrDefault()
                              : string.Join(", ", x.Attendees.OrderBy(a => a.ID).Take(2)
                                                             .Select(a => a.Person.CorrespondenceName).FirstOrDefault() + " ..."
                      : "No client name available";
