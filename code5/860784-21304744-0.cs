     foreach (var item in Roles.GetAllRoles())
     {
          if(Context.User.IsInRole(item))
          {
                //code
          }
          else
          {
                //code
          }
     }
