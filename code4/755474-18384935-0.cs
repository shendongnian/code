    void Main()
    {
    	//can create user but not read the information back
    	var userCanBeCreatedPermission = Permissions.Create | Permissions.User;
    	
    	//can create and readback
    	var userCanBeCreatedAndReadBackPermission = userCanBeCreatedPermission | Permissions.Read;
    	
    	userCanBeCreatedPermission.HasFlag(Permissions.User).Dump(); //returns true
    	
    	(userCanBeCreatedPermission.HasFlag(Permissions.User) && userCanBeCreatedPermission.HasFlag(Permissions.Read)).Dump(); //returns false
    	
    	//alternative way of checking flags is to combine the flags and do an And mask check
    	//the above can be written as
    	((userCanBeCreatedPermission & (Permissions.User | Permissions.Read)) == (Permissions.User | Permissions.Read)).Dump(); //returns false
    	
    	//using a variable to have combined permissions for readibility & using And mask:
    	var desiredPermissions = Permissions.User | Permissions.Read;
    	
    	//checking with user that has both Create & Read permissions
    	
    	((userCanBeCreatedAndReadBackPermission & desiredPermissions) == desiredPermissions).Dump(); // returns true because the user information can be read back by this user
    	
    	((userCanBeCreatedAndReadBackPermission & Permissions.Delete) == Permissions.Delete).Dump(); // returns false because the user can't be deleted
    }
    
    [Flags]
    public enum Permissions
    {
       None = 0,
       Create = 1 << 0,
       Read = 1 << 1,
       Update = 1 << 2,
       Delete = 1 << 3,
    
       User = 1 << 4,
       Group = 1 << 5
    }
