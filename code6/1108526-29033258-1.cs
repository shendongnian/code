       public class CountryReportsHierarchy
    {
        IIsesServiceChannel IsesService;
        public ObservableCollection<tbArticleCategory> ArticleCategoryList;
        public ObservableCollection<ArticleCategoriesHierarchy> ArticleCategoriesHierarchyCollection { get; set; }
        public string Name { get; set; }
        public CountryReportsHierarchy(IIsesServiceChannel isesService)
        {
            this.IsesService = isesService;          
            ArticleCategoryList = new ObservableCollection<tbArticleCategory>(IsesService.GetArticleCatagoryTitles());           
            ArticleCategoriesHierarchyCollection = new ObservableCollection<ArticleCategoriesHierarchy>();
            foreach (var a in ArticleCategoryList)
            {
                ArticleCategoriesHierarchyCollection.Add(new ArticleCategoriesHierarchy(IsesService, a.Category) { Name = a.CategoryTitle });
            }
        } 
    }
    public class ArticleCategoriesHierarchy
    {
        IIsesServiceChannel IsesService;
        public ObservableCollection<tbArticleType> ArticleTypeList;
        public ObservableCollection<ArticleTypesHierarchy> ArticleTypesHierarchyCollection { get; set; }
        public string Name { get; set; }
        public ArticleCategoriesHierarchy(IIsesServiceChannel isesService, string articleCategoryType)
        {
            this.IsesService = isesService;
            ArticleTypeList = new ObservableCollection<tbArticleType>(IsesService.GetArticleCategoryTypes(articleCategoryType));
            ArticleTypesHierarchyCollection = new ObservableCollection<ArticleTypesHierarchy>();
            foreach (var a in ArticleTypeList)
            {
                ArticleTypesHierarchyCollection.Add(new ArticleTypesHierarchy() { Name = a.ArticleTitle });
            }
        }
    }
    public class ArticleTypesHierarchy
    {
        public string Name { get; set; }
    }
