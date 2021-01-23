    public ActionResult Get()
    {
        var model = new ViewModel {
            DCResults = this.DcResultRepos.DCResults
        };
        return View(model);
    }
    
    public ActionResult Post(ViewModel model) {
        if (ModelState.IsValid) {
            //do something 
        }
        return View("Another View");
    }
