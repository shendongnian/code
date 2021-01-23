      Public Class tblUser
        {
        public string UserId  {get; set;} 
        public string UserName  {get; set;} 
        public string RoleIds {get; set;} 
        public string RoleName {get; set;}                   
        }
    var results = (from h in users
                   join  n Role on h.RoleIds  equal  n.RoleId
                     select new tblUser
                      {
                        UserId = h.UserId,
                        UserName = h.UserName,
                        RoleName  = n.RoleName 
                      }
                   );
