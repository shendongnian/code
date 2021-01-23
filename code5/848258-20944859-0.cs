    protected readonly ArticleSummariesTableAdapter SummariesAdapter
    {
      get
      {
         if (_ArticleSummariesAdapter == null)
         {
           _ArticleSummariesAdapter = New ArticleSummariesTableAdapter();
         }
         return _ArticleSummariesAdapter;
      }
    }
