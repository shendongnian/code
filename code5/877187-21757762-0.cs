    var query = (from article in _session.Query<Article>()
                         where article.Parent == articleList && article.PublishOn != null
                         group article by new { article.PublishOn.Value.Year, article.PublishOn.Value.Month } into entryGroup
                         select new ArchiveModel
                         {
                             Year = entryGroup.Key.Year,
                             Month = entryGroup.Key.Month,
                             Count = entryGroup.Count()
                         });
