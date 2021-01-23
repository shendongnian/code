    public class Company
    {
        public virtual ICollection<Article> Articles { get; set; }
        public IEnumerable<int> ArticlesIds
        {
    	    get { return Articles.Select(a => a.Id); }
        }
    }
