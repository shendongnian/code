        // GET: /Admin/
        public ActionResult Create()
        {
            ViewBag.headerTitle = "Create a User";
            ViewData["Organization"] = new SelectList(db.MemberOrganizations, "Id", "Name");
            ViewData["Sponsor"] = new SelectList(db.SponsorOrganizations, "Id", "Name");
            Users newUser = new Users();
            newUser.RegisteredDate = DateTime.Now;
            newUser.LastVisitDate = DateTime.Now;
            newUser.ProfilePictureSrc = null;
            return View(newUser);
        }
