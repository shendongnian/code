    public Int32 ArticleCount
    {
        get
        {
            if (this.ModelviewArticleObservableList == null)
            {
                return 0;
            }
            else
            {
                return this.ModelviewArticleObservableList.Count;
            }
        }
    }
