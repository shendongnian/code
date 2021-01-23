    void OnLoad(object sender, RoutedEventArgs e)
    {
        //Check if the event is not raised by the visual studio designer
        if(DesignerProperties.GetIsInDesignMode(this))
          return;
    
        //Set the data context:
        this.DataContext = //Your viewmodel here
    }
