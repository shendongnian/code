    public class UpdateViewModel
    {
        public string givenName { get; set;}
    }
    public ActionMethod Put()
    {
        var original = GetOriginalLeaveModelSomehow();
        var viewModel = new UpdateViewModel();
    
        viewModel.givenName = original.givenName;
        // The idea is that the viewModel class contains only the fields you want to display to the user.
    
        return View(viewModel);
    }
    
    [HttpPost]
    public ActionMethod Put(UpdateViewModel viewModel)
    {
        var original = GetOriginalLeaveModelSomehow();
    
        originalMode.givenName = viewModel.givenName;
    
        Ileave.Update(original);
    }
