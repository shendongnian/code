    var query = studentRankTable.AsEnumerable()
                    .GroupBy(r => new { Name = r.Field<string>("ID"), Action = r.Field<string>("Name") })
                    .Select(grp => new StudentRank 
                    {
                        Name = grp.Key.Name,
                        Action = grp.Key.Action,
                        Count = grp.Count()
                    });
