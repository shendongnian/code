    public ActionResult Index()
    {    
       var users = _db.Users.Include("Projects").ToList();
       var model = new ListModel();
       var flexModel = new FlexModel();
       model.StaffModelList = new List<StaffModel>();
       foreach (var u in users)
       {
           var staffModel = new StaffModel();
           staffModel.Projects.AddRange(u.Projects); //These are user specific projects. If there are no projects assigned to user, this list will be empty.
           staffModel.Flex = flexModel;
           staffModel.Flex.User = u;
           staffModel.Flex.FlexTime = GetFlex.Flex(u.UserId);
           model.StaffModelList.Add(staffModel);
       }
        return View(model);
    }
