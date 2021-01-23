    public class Blog
    	{
    		public int BlogId { get; set; }
    		public string Url { get; set; }
    
    		public Guid BlogGuid { get; set; } = Guid.NewGuid();
    
    		public List<Post> Posts { get; set; }
    	}
