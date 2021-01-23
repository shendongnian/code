    public class AddCompanyViewModel
    {
        public CompanyModel Company { get; set; }
        public string Territories { get; set; }
    }
    [HttpPost]
    public ActionResult Save(AddCompanyViewModel model)
    {
        if (!ModelState.IsValid)
            return View((model.Company.CompanyId == 0)?"Add":"Edit",  model);
    
        _companyService.Save(model.Company);
        
        // Do something with territories...
        var territories = string.Split(model.Territories, ',');
        return RedirectToAction("Index");
    }
