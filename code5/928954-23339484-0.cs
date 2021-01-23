    public class ImageArticleMapping : SubclassMapping<ImageArticle>
    {
        public ImageArticleMapping()
        {
            this.Bag(x => x.Images)
        }
    }
