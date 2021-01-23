    var news = db.News.Where(n => n.UrlSlug.Equals(urlSlug))
      .ToList();
    foreach(var new in news)
    {
      new.Views += 1;
    }
    db.SaveChanges();
    NewsDetailVM vm = news.Project().To<NewsDetailVM>().FirstOrDefault();
