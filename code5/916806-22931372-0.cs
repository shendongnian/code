    [HttpGet]
    public ActionResult DisplayForm()
        {
           FormModel model=new FormModel();
                 return View(model);
        }
    [HttpPost]
    public ActionResult DisplayForm(FormModel model)
        {
           var employeeName=model.Empname;
                 return View();
        }
