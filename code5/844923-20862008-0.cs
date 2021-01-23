    class Article
    {
    	public DateTime PostDate { get; set; }
    	public string Title { get; set; }
    	
    	public Article(DateTime postDate, string title)
    	{
    		PostDate = postDate;
    		Title = title;
    	}
    }
