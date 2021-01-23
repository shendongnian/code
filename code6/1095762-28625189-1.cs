    IArticleRepository articleRepo = unitOfWork.ArticleRepository;
    List<Article> articles = new List<Article>(
                         articleRepo.GetAll()
                         .Where(a => a.Title == searchTerm &&
                                     a.Categories.Any(c => c.CategoryID == 4))
                         .OrderByDescending(a => a.CreatedDate));  
