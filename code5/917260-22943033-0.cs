    public class PostModel
    {
    	public int ContactID { get; set; }
    	public int SalutationID { get;  set; }
    	public string FirstName { get; set; }
    }
    
    public class PostView
    {
    	public ContactManager contact { get; set; }
    	public PostModel post { get; set; }
    }
