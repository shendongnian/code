    public ActionResult YourAction()
    {
            List<ActionType> actionType = GetCourses();
            var model = new BloodGroup()
            {
                ActionsList = (from action in actionType
                    select new SelectListItem
                    {
                        Text = action.BloodGroup,
                        Value = ((int) action.GroupId).ToString(),
                        Selected = action.BloodGroup.Equals("A+")
                    })
            };
            return View(model);
    }
