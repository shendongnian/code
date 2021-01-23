    public List<SelectListItem> GetActionTypes()
    {
       List<SelectListItem> actionTypesList = new List<SelectListItem>();
       actionTypesList = db.ActionTypes
                        .Select(s => new SelectListItem { Value = s.ID.ToString(),
                                                          Text = s.Name }).ToList();
       return actionTypesList;
    }
