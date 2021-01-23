     public ActionResult Edit(int id) {
         var user = MyDbContext.Users.Find(id);
         var model = new Model {
             User = user;
             SelectedRoles = user.UserRoles.Select(userRole => userRole.Role.Id).ToList();
             AvailableRoles = MyDb.Context.Roles.ToList();
         };
         return View(model);
     }
     [HttpPost]
     public ActionResult Edit(UserRoleViewModel model) {
         if (ModelState.IsValid) {
             var user = MyDbContext.Users.Find(id).CloneMatching(model.User);
             user.UserRoles.Clear();
             MyDbContext.SaveChanges();
             foreach( var roleId in model.SelectedRoles) {
                 users.UserRoles.Add(new UserRole {
                     UserId = user.Id,
                     RoleId = roleId
                 });
             }
             MyDbContext.SaveChanges();
             return RedirectToAction("Index");
         }        
         return View(model);
     }
