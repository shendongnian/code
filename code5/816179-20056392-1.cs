    public class UserDynamicNodeProvider : DynamicNodeProviderBase
    {
    	private readonly UserDao userDao;
    
    	public UserDynamicNodeProvider(UserDao userDao)
    	{
    		if (userDao == null)
    			throw new ArgumentNullException("userDao");
    		
    		this.userDao = userDao;
    	}
    	
    	public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
    	{
    		// Create a node for each element 
    		foreach (User user in this.userDao.GetAll())
    		{   
    			DynamicNode dynamicNode = new DynamicNode();
    			dynamicNode.Title = user.UserName;
    			dynamicNode.Description = user.UserName;
    			dynamicNode.RouteValues.Add("id", user.IdUser);
    			dynamicNode.ParentKey = "TheParentKey";
    			dynamicNode.Clickable = false;
    			dynamicNode.Area = "MyArea";
    
    			yield return dynamicNode;
    		}
    	}
    }
