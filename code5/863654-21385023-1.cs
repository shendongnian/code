    lstTraining.SelectMany(t => t.Subjects, (t, s) => new{t,s})
               .SelectMany(ts => ts.s.Users, (ts, u) => new{ts.t, ts.s, u})
               .GroupBy(tsu => tsu.u)
               .Select(g => new UserData 
                          {
                          UserId = g.Key.UserId,
                          FullName = g.Key.FullName,
                          SubjectNames = g.Select(tsu => tsu.s.Name)
                                          .Distinct()
                                          .ToList(),
                          TrainingNames = string.Join(", ",
                                                      g.Select(tsu => tsu.t.Name)
                                                       .Distinct())
                         }
                    
                       );      
