    var q = from d in db.Table
            where d.Id == 1
            group d by d.Id into g
            select new
            {
                Id = g.Key, // shown for illustrative purposes
                ColumnMin = g.Min( gi => gi.Column ),
                ColumnMax = g.Max( gi => gi.Column )
            };
    var result = q.SingleOrDefault();
