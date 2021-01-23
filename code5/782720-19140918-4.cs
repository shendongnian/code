    using (var dc = new CompanyListIdDBContext())
    {
        var content = from p in db.Companies
           select new { p.CoId, p.CompanyName };
        
        ViewBag.CompaniesList = content
            .Select(c => new SelectListItem
            {
                Text = c.CompanyName,
                Value = c.CoId.ToString()
            }).ToList();
    }
