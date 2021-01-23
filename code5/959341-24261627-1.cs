     var data = DataBase.Table1
                .Join(DataBase.Table2,
                    t1 => t1.Id,
                    t2 => t2.Id,
                    (t1, t2) => new { Value = t1.Id, Text = t2.Description }
                )
                .AsEnumerable() //otherwise next operator cannot be translated to SQL
                .Select((x,i) => new { x.Value, x.Text, Index = i})
                .OrderBy(x => x.Id)
                .ToList();
