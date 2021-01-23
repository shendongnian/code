    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LogInService
    {
        [ServiceContract]
        interface IUser
        {
            [OperationContract]
            bool ValidateUser(User user);
        }
    }
