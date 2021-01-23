    [ValidateInput(false)]
    [AcceptVerbs("POST")]
    public ActionResult Index([Bind(Exclude = "id")]Model.Model model)
    {
        var modId = Request["id"];
        //get model
        var model = LoadModel();
        
        //pass it to the view
        return View(model);
    }
