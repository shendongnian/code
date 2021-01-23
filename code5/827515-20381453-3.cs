    [HttpPost]
    public ActionResult Create(Prm_Staff_View_Model viewModel)
    {
       //Here you map your viewModel against the model and save it. 
       var myModel = new Prm_Staff();
       myModel.SalutationID = viewModel.SelectedSalutationID;
    }
