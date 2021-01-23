    public ActionResult Group(int ID)
    {
      // Get your data model
      ....
      MyModelVM model = new MyModelVM();
      model.Groups = new List<GroupVM>();
      // Populate the collection based on your data model
      foreach(var item in yourDataModel.Groups)
      {
        GroupVM group = new GroupVM();
        // apply you logic here
        if(item.AdminOnly && !item.IsUserAdministrator)
        {
          continue; // no point displaying these
        }
        group.ID = item.ID;
        group.DisplayName = string.Format("{0} - {1}", item.Name, item.Description)
        group.IsMember = item.IsMember;
        model.Groups.Add(group);
      }
      if (model.Groups.Count == 0)
      {
        // ?? is there any point displaying a form?
      }
      return View(model);
    }
