    var res = db.Item.Join(db.Comment, x=>x.ID, x=>x.ID, (x,y)=>new{x,y})
                .OrderByDescending(a=>a.y.Created)
                .GroupBy(a=>a.x.ID,(key,items)=>items.First())
                .Select(a=> new {
                           a.x.ID,
                           a.x.Name,
                           a.y.Message
                       });
