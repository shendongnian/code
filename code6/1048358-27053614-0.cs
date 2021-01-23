    var leftOuter = from p in posts
                    join c in comments on p.Id equals c.Id into groupJoin
                    let c = groupJoin.SingleOrDefault()
                    select new { Id = p.Id, Total = p.Points + (c == null ? 0 : c.Points) };
    var rightAnti = from c in comments
                    join p in posts on c.Id equals p.Id into groupJoin
                    let p = groupJoin.SingleOrDefault()
                    where p == null
                    select new { Id = c.Id, Total = c.Points };
    var result = leftOuter.Concat(rightAnti);
