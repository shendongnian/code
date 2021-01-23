    public ArticleViewModel
    {
        private IMyServiceClient ServiceClient { get; set; }
        public ArticleViewModel(IMyServiceClient serviceClient)
        {
            this.ServiceClient = serviceClient;
        }
        // etc.
    }
