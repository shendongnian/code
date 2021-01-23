    public async Task LaunchDialog(MyDialogVM vm)
    {
       var customDialog = new CustomDialog { Title = "Some Title" };
       var view = new MyDialogView{DataContext = vm};   // instance of the view user control
       customDialog.Content = view;
       // this registers the vm with CaliburnMicro, hence all life-cycle events are available
       ActivateItem(vm);    
    
       await _dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
       
    }
