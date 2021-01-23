result = (from articles in db.Articles
                              join articlecategories in db.ArticleCategories on articles.ArticleID equals articlecategories.ArticleID
                              join cat in db.Categories on articlecategories.CategoryID equals cat.CategoryID
                              join auth in db.Authors on articles.AuthorID equals auth.AuthorID
                              join tags in db.ArticleTags on articles.ArticleID equals tags.ArticleID
                              
                              select new ArticleViewModel
                              {
                                  ArticleID=articles.ArticleID,
                                  AuthorName = auth.AuthorName,
                                  Username = auth.UserName,
                                  Title = articles.Title,
                                  Slug = articles.Slug,
                                  ArticleContent = articles.ArticleContent,
                                  PostDate = articles.PostDate,
                                  CategoryNames = from icat in articles.ArticleCategories select icat.Category.CategoryName,
                                  Tags = from itags in articles.ArticleTags select itags.Tag.TagName
              
                              }).GroupBy(a => a.Title).Select(a => a.FirstOrDefault()).ToPagedList(pageIndex, pageSize);</pre>
