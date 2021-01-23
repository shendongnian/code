     if (user.Type1.nom == "lecteur")
     {
         if( ! Roles.IsUserInRole(user.login,"lecteur")
         {
            Roles.AddUserToRole(user.login, "lecteur");
         }
     }
     //and so on
