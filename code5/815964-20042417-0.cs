    var dataContext = new PersonEntryViewModel();
    this.ContentPanel.DataContext = dataContext.CurrentPerson;
    // After creating App bar
    this.appBar.DataContext = dataContext;
    Binding buttonBinding = new Binding();
    buttonBinding.Path = new PropertyPath("EnableSaveButton"); // here
    
    buttonBinding.Source = dataContext ; // and here
    
    buttonBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    
    appBar.SaveButton.SetBinding(Button.IsEnabledProperty, buttonBinding);
    
