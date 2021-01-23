    private ConnectContext db = new ConnectContext();
    public ActionResult Index()
    {
        FirstModel firstModel = //Set FirstModel Value;
        SecondModel secondModel = //Set SecondModel Value;
        
        ViewModel viewModel = new ViewModel(){
            FirstModel = firstModel,
            SecondModel = secondModel
        }
    
        return View(viewModel);
    }
