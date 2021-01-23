    public class ImageMap : ClassMapping<Image>
    {
        public ImageMap()
        {            
            ManyToOne(x => x.Article, m =>
            {
                m.NotNullable(true);
                m.Class(typeof(MyArticle));
            });
        }
    }
