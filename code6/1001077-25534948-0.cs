    public interface ISearchEngine
    {
        void Search();
    }
    public class Site
    {
        ISearchEngine searchHandler = null;
        public Site(ISearchEngine searchHandler )
        {
            this.searchHandler = searchHandler;
        }
        public void DoSearch()
        {
            searchHandler.Search();
        }
    }
    public class GoogleSearch : ISearchEngine
    {
        public virtual void Search()
        {
            Console.Write("Google Search.");
        }
    }
    public class YahooSearch : ISearchEngine
    {
        public virtual void Search()
        {
            Console.Write("Yahoo Search.");
        }
    }
    public class BingSearch : ISearchEngine
    {
        public virtual void Search()
        {
            Console.Write("Bing Search.");
        }
    }
    public class BingSearchV1 : BingSearch
    {
        public override void Search()
        {
            Console.Write("Bing V1 Search.");
        }
    }
