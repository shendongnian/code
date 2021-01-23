    public ActionResult YourAction()
    {
        var model = new CompanyViewModel();
        using (var dc = new CompanyListIdDBContext())
        {
            var content = from p in db.Companies
                select new { p.CoId, p.CompanyName };
        
            model.CompaniesList = content
                .Select(c => new SelectListItem
                {
                    Text = c.CompanyName,
                    Value = c.CoId.ToString()
                }).ToList();
        }
        return View(model);
    }
