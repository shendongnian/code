    public async Task<ActionResult> Create()
            {
                // Get the list of Roles
                ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
    
                return View();
            }
