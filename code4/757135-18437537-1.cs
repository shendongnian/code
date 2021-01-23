    public ActionResult Register()
    {
        MemberModel model = new MemberModel();
        model.MemberList = GetAllMembers()
            .Select(m => new SelectListItem
            {
                Text = string.format("{0}, {1}", m.Mem_NA, m.Mem_Occ),
                Value = m.Id
            });
        SelectListItem default = new SelectListItem
        {
            Text = "-- SELECT --",
            Value = 0
        };
        model.MemberList.Insert(0, default);
        return View(model);
    }
