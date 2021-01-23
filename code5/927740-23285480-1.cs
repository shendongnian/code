    public class ArticleBaseMap : ClassMapping<IArticle>
    {
        public ArticleBaseMap()
        {
            Discriminator(x =>
            {
                x.Column("discriminator");
