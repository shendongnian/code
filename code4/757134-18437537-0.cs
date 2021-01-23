    public ActionResult Register()
    {
        MemberModel model = new MemberModel();
        model.MemberList = GetAllMembers()
            .Select(m => new SelectListItem
            {
                Text = string.format("{0}, {1}", m.Mem_NA, m.Mem_Occ),
                Value = m.Id
            });
        return View(model);
    }
