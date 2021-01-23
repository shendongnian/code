       int point = 1000;          
       var ranks = Enumerable.Range(1,db.User.Count);
       var result = db.User.OrderByDescending(x => x.points).ThenBy(x => x.Name).Zip(ranks, (x,y) => new {x.Name, x.Point, rank = y});
       var top6= result.Where(x => x.Point>= point).OrderBy(x => x.Point).Take(6);            
       var bottom4 = result.Where(x => x.Point< point).OrderByDescending(x => x.Point).Take(4);
       var leaderboard = top6.Union(bottom4).OrderByDescending(x => x.Point).ThenBy(x => x.Name);
