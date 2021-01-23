    public ActionResult Index(){
        var model = new MyViewModel();
        model.ShowGraph = !IsStudentNew();
        // set your other properties here, instead of using the ViewBag
    
        return View( model );
    }
