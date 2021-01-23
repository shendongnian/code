    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LogInService
    {
        class LogInClass : IUser
        {
            public bool ValidateUser(User user) 
            {
                // connection to the database and checking user validity code goes here.
                throw new NotImplementedException();
            }
        }
    }
