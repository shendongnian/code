    [HttpGet]
    public ActionResult GetDetails()
    {
    
           var mainViewModel = new MainViewModel();
    
            mainViewModel.EmailAccounts=Repository.GetEmailAccounts();
            mainViewModel.Contacts=Repository.GetUserAccounts();
            mainViewModel.LinkedInProfiles=Repository.GetLinkedInProfiles(); 
            mainViewModel.Config=Repository.GetConfigData();
    
         return PartialView("ContactListWidget", mainViewModel );
    }
