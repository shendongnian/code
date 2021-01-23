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
              
                              }).GroupBy(a => a.Title).Select(a => a.FirstOrDefault()).ToList<ArticleViewModel>().ToPagedList(pageIndex, pageSize);
