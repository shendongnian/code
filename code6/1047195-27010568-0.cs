    var publisherList = (from aa in db.AccessArticles
                                     join u in db.Users on aa.UserId equals u.Id
                                     join a in db.Articles on aa.ArticleId equals a.Id
                                     where u.Id == userId
                                     orderby a.Title
                                     select new
                                     {
                                         UserName = u.UserName,
                                         ArticleTitle = a.Title,
                                         AccessArticleId = aa.AccessArticlesId,
                                         UserId = aa.UserId
                                     }).ToList();
