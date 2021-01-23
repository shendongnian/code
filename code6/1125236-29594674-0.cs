     .Union(from p in entities.Posts
            where friends_A.Any(f => f.Name == p.UserName)
            select new { p.UserName, p.DateAndTime, p.PostText })
     .Union(from p in entities.Posts
            where friends_B.Any(f => f.Name == p.UserName)
            select new { p.UserName, p.DateAndTime, p.PostText }));
