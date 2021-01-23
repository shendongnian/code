    //In View
    if(viewModel.CanSave)
    {
    ...
    }
    
    //In VieWModel
    SomeEnum Status 
    {
       set { _status = value; CanSave == _status == SomeEnum.HasChanged; }
    ...
