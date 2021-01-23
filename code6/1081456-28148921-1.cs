    public ActionResult Create()
    {
       var model = new SomeModel();
       model.SkillLevels = new List<SkillLevel>(4);
       for(int i=0;i<4;i++)
       {
          model.SkillLevels.Add(new SkillLevel());
       }
       return View("~/sth/Edit", model); //here should be path to your view
    }
