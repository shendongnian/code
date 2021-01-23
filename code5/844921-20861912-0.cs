    public class Article
    {
    	public DateTime PostDate {get;set;}
    }
    
    void Main()
    {
    	DateTime now = DateTime.Now;
        //create some fake data!
    	List<Article> articles = new List<Article>{
    										new Article{PostDate=now}, 
    										new Article{PostDate=now.AddMinutes(1)}, 
    										new Article{PostDate=now.AddMonths(1)}, 
    										new Article{PostDate=now.AddMonths(1).AddMinutes(1)}, 
    										new Article{PostDate=now.AddMonths(2)}, 
    										new Article{PostDate=now.AddMonths(2).AddMinutes(1)}, 
    										new Article{PostDate=now.AddMonths(4)},
    										new Article{PostDate=now.AddMonths(4).AddMinutes(1)}
    								};
    	
    	var groupedArticles = from a in articles
    						group a by a.PostDate.Year into articlesByYear
    							select new {
    								Year = articlesByYear.Key,
    								ArticlesByMonth = from a2 in articlesByYear
    												group a2 by a2.PostDate.Month into articlesByYearByMonth	
    												select articlesByYearByMonth
    							};
    						
    						
    	foreach (var articlesByYear in groupedArticles)
    	{
    		foreach (var articlesByMonthForCurrentYear in articlesByYear.ArticlesByMonth)
    		{
    			foreach (var article in articlesByMonthForCurrentYear)
    			{
    				Console.WriteLine("Year: " + articlesByYear.Year +" Month: " + articlesByMonthForCurrentYear.Key + " PostDate: " + article.PostDate);
    			}
    		}
    	}
    }
