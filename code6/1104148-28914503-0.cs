    public class ArticleViewModel : ViewModelBase 
    {
        private IServiceClient serviceClient;
        public ArticleViewModel(IServiceClient client) 
        {
            this.serviceClient = client;
        }
        private string LoadArticle(string userName) 
        {
            return this.serviceClient.GetArticle(userName);
        }
    }
