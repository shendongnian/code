    public ActionResult YourAction()
    {
        List<ActionType> actionType = GetCourses();
        var model = new BloodGroup();
        model.ActionsList =  (from action in actionType
                              select new SelectListItem
                              {
                                 Text = action.BloodGroup,
                                 Value = ((int)action.GroupId).ToString(),
                                 Selected = action.BloodGroup.Equals("A+")?true:false
                              }).ToList();
        return View(model);
    }
