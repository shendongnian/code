    public ActionResult Index(){
        var model = new MyViewModel();
        model.ShowGraph = !IsStudentNew();
    
        return View( model );
    }
