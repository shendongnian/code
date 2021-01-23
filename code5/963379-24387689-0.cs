    var query = RankTable.AsEnumerable()
                        .GroupBy(r => new { Name = r.Field<string>("Name"), Action = r.Field<string>("Action") })
                        .Select(grp => new
                        {
                            Name = grp.Key.Name,
                            Action = grp.Key.Action,
                            Count = grp.Count()
                        });
