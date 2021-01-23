        public ActionResult Edit(int? id)
        {
           // beginning of your action
           List<AspNetRole> roles = from r in db.AspNetRoles
                                    select r;
           model.Roles = new List<RoleViewModel>();
           foreach(AspNetRole role in roles){
	         model.Roles.Add(new RoleViewModel { 
               Id = role.Id, 
               Name = role.Name,
               Selected = user.AspNetRoles.Any(userRole => userRole.Id == role.Id)
             });
	       }
           // end of your action
        }
