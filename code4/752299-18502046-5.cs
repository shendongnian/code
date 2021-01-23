    public ActionResult Index()
        {
            // Create a new Patron object upon user's first visit to the page.
            _patron = new Patron((WindowsIdentity)User.Identity);
            Session["patron"] = _patron;            
            var lstGroups = new List<SelectionModel.GroupModel>();
            var rMgr = new DataStoreManager.ResourceManager();
            // GetResourceGroups will return an empty list if no resource groups where    found.
            var resGroups = rMgr.GetResourceGroups();
            // Add the available resource groups to list.
            foreach (var resource in resGroups)
            {
                var group = new SelectionModel.GroupModel();
                rMgr.GetResourcesByGroup(resource.Key);
                group.GroupName = resource.Value;
                group.GroupKey = resource.Key;
                lstGroups.Add(group);
            }
            return View(lstGroups);
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(SelectionModel.GroupModel item)
        {
            if (!ModelState.IsValid)
                return View();
            if (item.GroupKey != null && item.GroupName != null)
            {               
                var rModel = new SelectionModel.ReserveModel
                {
                    LocationKey = item.GroupKey,
                    Location = item.GroupName
                };
                Session["rModel"] = rModel;
            }           
    //So now my date model will have Group info in session ready to use
            return RedirectToAction("Date", "Home");
       }
