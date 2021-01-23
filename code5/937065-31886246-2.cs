    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.ServiceModel;
    
    namespace MyProject.Client
    {
    	[ServiceContract]
    	interface IUserService
    	{
    		[OperationContract]
    		List<User> GetAllUsers ();
    
    		[OperationContract]
    		Task<List<User>> GetAllUsersAsync ();
    	}
    }
