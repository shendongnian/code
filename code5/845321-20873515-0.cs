    public class Revision
    {
        public int revid { get; set; }
        public int parentid { get; set; }
    }
    public class Page
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public List<Revision> revisions { get; set; }
    }
    public class Query
    {
        public Dictionary<string,Page>  pages { get; set; }
    }
    public class RootObject
    {
        public Query query { get; set; }
    }
