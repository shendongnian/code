    public ActionResult Index()
    {
        List<IAlert> alerts = GetOutdoorAlerts(); //for example
    
        List<AlertViewModel> alertViewModels = alert
            .Select(a => new AlertViewModel
            {
                 AlertID = a.AlertID,
                 MessageID = a.MessageID,
                 //etc...
            });
    
        return View(alertViewModels);
    }
