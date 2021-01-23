    var query = catia_user_table.AsEnumerable().GroupBy(n => n.Department)
                                .Select(g => new
                                 {
                                    Department = g.Key,
                                    Licenses = g.Sum(n => n.Licensec)
                                 }).ToList();
