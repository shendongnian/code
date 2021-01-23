         public ActionResult Edit(ManageViewModel model){
          // beginning of your action
          // remove roles from user
          List<AspNetRoles> newRoles = new List<AspNetRoles>();
          foreach(RoleViewModel role in model.Roles){
            newRole.Add(db.AspNetRoles.Find(role.id))
          } 
          // set your user roles from newRoles
          // end of your action 
        }
