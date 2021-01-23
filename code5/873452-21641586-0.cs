    [HttpPost]
    public ActionResult ProjeEkle(OrgProje model)
    {
        try
        {
            svc.ProjeEkle(model);
            return RedirectToAction("Index", "Home");
        }
        catch(Exception ex)
        { 
        }
        return View(model); // Passing a view model of the wrong type to the view
    }
