    IArticleRepository articleRepo = unitOfWork.ArticleRepository;
    var articlesQuery = from article in articleRepo.GetAll()
                             where article.Title == searchTerm
                             where article.Category.CategoryId == categoryId
                             orderby article.CreatedDate descending
                             select article
    
    List<Article> articles = articlesQuery.ToList();
