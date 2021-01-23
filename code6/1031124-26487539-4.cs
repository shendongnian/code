    list.GroupBy(a => a.FK_ArticleId)
        .Select(g => new Article() {FK_ArticleId = g.Key, Quantity = g.Sum(a => a.Quantity)});
    // article id 1, quantity 30
    // article id 2, quantity 200
    // article id 3, quantity 1000
