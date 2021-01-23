    public class ArticleCompany
    {
    	public int CompanyId { get; set; }
    	public int ArticleId { get; set; }
    
    	public virtual Company Company { get; set; }
    	public virtual Article Article { get; set; }
    }
