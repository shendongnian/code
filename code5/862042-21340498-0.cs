    public class PagerBase<T> where T:EntityBase
    {
        public List<T> items {get;set;}
        public int totalpage {get;set;}
        public int pageindex {get;set;}
        public int pagesize  {get;set;}
    
        public PagerBase(IEnumerable<T> source, int totalpage, int pageindex, int pagesize)
        {
            this.items = source.ToList();
            this.totalpage = totalpage;
            this.pageindex = pageindex;
            this.pagesize = pagesize;
        }
    }
