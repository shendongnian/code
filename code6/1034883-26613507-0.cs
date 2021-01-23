    [GridAction(EnableCustomBinding = true)]
    public ActionResult SelectHandled(GridCommand command)
    {
        IEnumerable<MyViewModel> items = _repository.Get();
    
        var vms = Mapper.Map<IEnumerable<MyModel>, IEnumerable<MyViewModel>>(items);
    
       var retColl = new GridModel(vms) { Total = command.PageSize * command.Page };
	   return View(retColl);
    }
