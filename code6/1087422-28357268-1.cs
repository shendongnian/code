    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ServerInfoViewModel model)
    {
        if (ModelState.IsValid)
        {
            db.Servers.Add(model.ServerInfo);
            db.System_Build_Information.Add(model.SystemBuildInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        ViewBag.Server_Role = new SelectList(db.Server_Roles, "Id", "Server_Role", server.Server_Role);
        ViewBag.Server_OS = new SelectList(db.Operating_System, "Id", "Operating System", server.Server_OS);
        string[] environments = new string[] { "Virtual", "Physical" };
        ViewBag.Environments = new SelectList(environments);
        return View(model);
    }
