    using System.Collections.Generic;
    using System.ServiceModel;
    
    namespace MyProject
    {
        [ServiceContract]
        interface IUserService
        {
            [OperationContract]
            List<User> GetAllUsers();
        }
    }
