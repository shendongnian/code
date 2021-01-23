    public View(IMVVM MyViewModel)
    {
      this.ViewModel = MyViewModel;
      //The code below will fail to register the handler but it won't raise any errors
      this.ViewModel.PropertyChanged += new PropertyChangedEventHandler(DeveloperInfoChanged_Handler);
    }
    protected virtual void DeveloperInfoChanged_Handler(object sender, PropertyChangedEventArgs e)
    {
      //This will not be triggered by an update in the viewmodel
      UpdateDisplay();
    }
