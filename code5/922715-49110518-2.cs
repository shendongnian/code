    public class PageManager
    {
        private readonly ContentPageRepository _pageRepository;
        public PageManager()
        {
            _pageRepository = RepositoryFactory.CreateDynamic<ContentPage>();
        }
    
        public void GetPagesByContentType(ContentType type)
        {
            var pages = _pageRepository.GetByPredicate(x => x.Status != EntityStatus.Deleted && x.Node.Type == type);
            foreach (var page in pages)
            {
                //Deal with it :)
            }
    
        }
    }
