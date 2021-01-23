    public partial class FeatureArticle
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
    public partial class Article
    {
        public Article()
        {
            this.FeatureArticles = new List<FeatureArticle>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public virtual ICollection<FeatureArticle> FeatureArticles { get; set; }
    }
