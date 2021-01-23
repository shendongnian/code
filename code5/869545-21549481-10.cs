    private IEnumerable<SelectListItem> GetAllRecStatus()
    {
        var recStatusDA = new RecStatusDA();
        IEnumerable<SelectListItem> slItem = from s in recStatusDA.GetAll()
                                                select new SelectListItem
                                                {
                                                    Selected = s.RecStatusId.ToString() == "default value you want to set"
                                                    Text = s.RecStatusName,
                                                    Value = s.RecStatusId.ToString()
                                                };
        return slItem;
    }
    public ActionResult LogTypeCreate()
    {
        var model = new LogTypeModel.LogType { selectList = GetAllRecStatus() };
        return View(model);
    }
