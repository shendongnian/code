    //
    // GET: /Users/Edit/Bob
    public async Task<ActionResult> Edit(string userName)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
       
        var user = await UserManager.FindByNameAsync(userName);
        if (user == null)
        {
            return HttpNotFound();
        }
    
        var userRoles = await UserManager.GetRolesAsync(user.Id);
    
        return View(new EditUserViewModel()
        {
            Id = user.Id,
            Email = user.Email,
            RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
            {
                Selected = userRoles.Contains(x.Name),
                Text = x.Name,
                Value = x.Name
            })
        });
    }
