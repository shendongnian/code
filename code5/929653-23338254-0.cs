    public class ArticleBaseMap : ClassMapping<ArticleBase>
    {
        public ArticleBaseMap()
        {
            Property(x => x.Category, m =>
            {
                m.NotNullable(true);
            });
            // ...
        }
    }
