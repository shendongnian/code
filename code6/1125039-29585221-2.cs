    public static class Mappings
    {
        public static ArticleDescriptionViewModel ConvertToView(this ArticleDescription article)
        {
            // Mapping Code
            // return new ArticleDescriptionViewModel { ... }
        }
    
        public static List<ArticleDescriptionViewModel> ConvertToViews(this List<ArticleDescription> articles)
        {
            List<ArticleDescriptionViewModel> articleViews = new List<ArticleDescriptionViewModel>();
    
            foreach (ArticleDescription article in articles)
            {
                articleViews.Add(article.ConvertToView())
            }
        }
    }
