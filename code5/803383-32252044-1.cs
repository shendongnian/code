        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
           if (ModelState.IsValid)
           {
               var role = new IdentityRole(roleViewModel.Name);
               var roleresult = await RoleManager.CreateAsync(role);
               if (!roleresult.Succeeded)
               {
                   ModelState.AddModelError("", roleresult.Errors.First());
                   return View();
               }
               return RedirectToAction("some_action");
           }
           return View();
        }
