      var qry = items.GroupBy(item => new { item .Age, item .Name },
               (key, group) => new
               {
                   Key1 = key.Age,
                   Key2 = key.Name,
                   All = group.ToList()
               });
