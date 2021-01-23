    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace LogInService
    {
        [DataContract]
        class User
        {
            [DataMember]
            public string UserName { get; set; }
    
            [DataMember]
            public string Password { get; set; }
        }
    }
