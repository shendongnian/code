    public ActionResult Index(int? id)
    {
        List<MyModel> mod = new List<MyModel>() { 
            new MyModel { SelectedValue = 1 } ,
            new MyModel {SelectedValue = 2},
            new MyModel {SelectedValue = 3}
        };
            return View(mod);
    }
