    public static class Mappings
    {
        public static ArticleDescriptionViewModel ConvertToView(this ArticleDescription article)
        {
            // Mapping Code
        }
    
        public static List<ArticleDescriptionViewModel> ConvertToViews(this List<ArticleDescription> articles)
        {
            List<ArticleDescriptionViewModel> articleViewModels = new List<ArticleDescriptionViewModel>();
    
            foreach (ArticleDescription article in articles)
            {
                articleViewModels.Add(article.ConvertToViewModel())
            }
        }
    }
