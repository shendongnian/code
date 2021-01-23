    var commentData = (from o in quack.BlogComments
                       join u in quack.AdminUsers
                       on o.UserId equals u.AdminUserId
                       where blogid == o.BlogId
                       select new
                       {
                           o.Comment,
                           o.CommentDate,
                           u.FirstName,
                           u.LastName
                       }).Concat(from o in quack.BlogComments
                                 join u in quack.RegularUsers
                                 on o.UserId equals u.RegularUserId
                                 where blogid == o.BlogId
                                 select new
                                 {
                                     o.Comment,
                                     o.CommentDate,
                                     u.FirstName,
                                     u.LastName
                                 });
    
    var l = commentData.ToList();
