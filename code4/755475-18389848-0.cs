    void Main()
    {
    	// Permissions definition
    	var userCreate = new Authorization<User>(Permissions.Create);
    	var userRead = new Authorization<User>(Permissions.Read);
    	
    	var carrotCreate = new Authorization<Carrot>(Permissions.Create);
    	var carrotRead = new Authorization<Carrot>(Permissions.Read);
    	
    	// User
    	var user = new User();
    		
    	// User has no permissions yet
    	if(user.IsAuthorized<User>(Permissions.Create))
    		"I can create User".Dump();
    	else
    		"No creating User for me".Dump();
    	
    	// Now user can Create users
    	user.Authorizations.Add(userCreate);			
    	if(user.IsAuthorized<User>(Permissions.Create))
    		"I can create User".Dump();
    	else
    		"No creating User for me".Dump();
    			
    	// User can read carrots
    	user.Authorizations.Add(carrotRead);
    
    	if(user.IsAuthorized<Carrot>(Permissions.Create))
    		"I can create carrots".Dump();
    	else
    		"No creating carrots for me".Dump();
    	
    	if(user.IsAuthorized<Carrot>(Permissions.Read))
    		"I can read carrots".Dump();
    	else
    		"No reading carrots for me".Dump();
    
    	// User can now create carrots
    	user.Authorizations.Add(carrotCreate);
    	if(user.IsAuthorized<Carrot>(Permissions.Create))
    		"I can create carrots".Dump();
    	else
    		"No creating carrots for me".Dump();			
    			
    }
     
    [Flags]
    public enum Permissions : ulong
    {
    	Create = 1 << 0,
    	Read = 1 << 1,
    	Update = 1 << 2,
    	Delete = 1 << 3
    }
     
    public abstract class Auth{
     
    }
    public class Authorization<T> : Auth {
    	public Authorization(Permissions permissions){ this.Permissions = permissions; }
    	public Permissions Permissions {get;set;}
    }
     
    public class Carrot{
    	public int Id{get; set;}
    }
     
    public class User{
    	public User(){ Authorizations = new List<Auth>(); }
    	public List<Auth> Authorizations{get; set;}
    	public bool IsAuthorized<T>(Permissions permission){
    		foreach(var auth in Authorizations)
    			if(auth is Authorization<T>){
    				var a = auth as Authorization<T>;
    				if(a.Permissions == permission)
    					return true;
    			}
    				
    		return false;
    	}
    }
