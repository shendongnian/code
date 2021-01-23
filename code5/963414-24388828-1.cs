    Select(grp => new StudentRank
                  {
                      Name = grp.Key.Name,
                      Action = grp.Key.Action,
                      Count = grp.Count()
                  });
