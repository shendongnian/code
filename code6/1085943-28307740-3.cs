    public ActionResult ListCompanies(string id)
    {
      var query = db.AY_COMPANIES;
      if (!string.IsNullOrWhiteSpace(id))
      {
        query.Where(c => c.COMPANY_FULL_NAME.StartsWith(id))
      }
      var model = query.ToList();
      return View(model);
    }
