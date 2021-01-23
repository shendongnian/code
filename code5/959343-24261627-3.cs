     var data = DataBase.Table1
                .GroupJoin(DataBase.Table2,
                    t1 => t1.Id,
                    t2 => t2.Id,
                    (t1, t2items) => new { Value = t1.Id, t2items }
                )
                .AsEnumerable() //otherwise next operator cannot be translated to SQL
                .SelectMany(x => x.t2items.Select((t2, i) => 
                   new { x.Value, Text = t2.Description, Index = i}))
                .OrderBy(x => x.Value)
                .ToList();
