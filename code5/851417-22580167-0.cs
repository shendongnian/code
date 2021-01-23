    public ActionResult Index(MyModel model)
    {
                if( !ModelState.IsValid){
                  var errors = this.ModelState.Values.SelectMany(x => x.Errors);
                }
            
               return View();
    }
