    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security;
    
    namespace ImpersonationUtil
    {
        public class AccountCredentials
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Domain { get; set; }
    
            public AccountCredentials(string userName, string password, string domain)
            {
                UserName = userName;
                Password = password;
                Domain = domain;
            }
        }
    }
