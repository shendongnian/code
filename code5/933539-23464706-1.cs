    public View(IMVVM MyViewModel)
    {
      this.ViewModel = MyViewModel;
      //Below makes viewmodel reference this view instance
      this.ViewModel.Visit(this);
      this.ViewModel.PropertyChanged += new PropertyChangedEventHandler(DeveloperInfoChanged_Handler);
    }
    
    //Viewmodel updates the view when model data changes
    public void ChangeDeveloperInfo(string strNewName)
    {
      developer.Name = strNewName;
      view.UpdateDisplay();
    }
