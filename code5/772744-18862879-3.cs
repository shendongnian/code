    public partial class BasePage : Page
    {
        protected new CacheHandler Cache
        {
            get { return CacheHandler.Current; }
        }
    }
