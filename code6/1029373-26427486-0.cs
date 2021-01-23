    public class News
    {
        public string Title { get; set; }
        public string Url { get; set; }
    
        public IQueryable<News> GetNews()
        {
            var news = new List<News> {new News {Title = "News1", Url = "NewsURL"}, 
                                       new News {Title = "News1"}};
            return news.AsQueryable(); 
        }
    }
