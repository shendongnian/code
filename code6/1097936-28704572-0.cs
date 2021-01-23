        var initial_group = from st in this                            group st by new {  st.TestName, st.School, st.Teacher }
                                into testGroups
                                where testGroups.Count() > 10
                                select new
                                {
                                    Test = testGroups.Key.TestName,
                                    School = testGroups.Key.School,
                                    Teacher = testGroups.Key.Teacher,
                                    Items = testGroups
                                };
        var results = from grp in initial_group
                      group grp by grp.Test
                          into testGroups
                          select new
                              {
                                  Test = testGroups.Key,
                                  NumSchools = testGroups.Select(a => a.School).Distinct().Count(),
                                  NumTeachers = testGroups.Select(a => a.Teacher).Distinct().Count()
                              };
