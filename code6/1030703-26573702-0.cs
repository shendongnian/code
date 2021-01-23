    public class AdvancedContentLoader : IContentLoaderWithPageSecurity 
    {
        private readonly IContentLoader _internalContentLoader;
        private IPageSecurity _pageSecurity;
        public AdvancedContentLoader(IContentLoader contentLoader, IPageSecurity pageSecurity)
        {
            _internalContentLoader = contentLoader;
            _pageSecurity = pageSecurity;
        }
        // Chain calls on the interface to internal content loader
        public T LoadItem<T>(Guid id) where T : Page
        {
            return _internalContentLoader.LoadItem<T>(id);
        }
        public IEnumerable<T> LoadAllChildItems<T>(IContentLoader contentLoader, Guid id)
        {
            // do whatever you need to do here
            yield break;
        }
    }
