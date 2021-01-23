    /// <summary>
    /// Set up property changed events. Call on initialisation
    /// </summary>
    private void SetupPropertyChanged()
    {
      if (Model != null)
      {
        Model.PropertyChanged -= Model_PropertyChanged;
        Model.PropertyChanged += Model_PropertyChanged;
      }
    }
    
    
    public void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
    // do stuff here.
    }
