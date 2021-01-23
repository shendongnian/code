    var articles = from article in dbContext.KBArticles.AsEnumerable()
                   select new ArticlesListModel()
                   {
                       Id = article.Id,
                       Title = article.Title,
                       Tags = string.Join(" ", article.Tags.Select(t => t.Title).ToArray<string>())
                   };
