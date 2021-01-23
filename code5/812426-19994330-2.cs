    public class MySampleItem
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }
    
        [SolrField("title")]
        public string Title { get; set; }
    
        [SolrField("content")]
        public string Content { get; set; }
    
        [SolrField("url")]
        public string FriendlyUrl { get; set; }
    
        [SolrField("score")]
        public float Score { get; set; }
    
        [SolrField("date")]
        public DateTime PublishDate { get; set; }
    }
