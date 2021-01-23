    public class UserDataViewModel
    {
        public string Username { get; set; }
        public bool AllowDirectEmails { get; set; }
        // etc ...
    }
    
    public ActionResult UserData()
    {
        var viewModel = new UserDataViewModel();
    
        viewModel.UserName = "Whatever";
        viewModel.AllowDirectEmails = false;
    
        // Or however you get the data for the user.....
    
        return View(viewModel) 
    }
