    public class BaseController : Controller
    {
    	private ConcurrentDictionary<string, CustomUserData> _users;
    	protected ConcurrentDictionary<string, CustomUserData> Users
    	{
    		get
    		{
    			if (_users == null)
    			{
    				_users = new ConcurrentDictionary<string, CustomUserData>();
    			}
    			return _users;
    		}
    	}
    }
