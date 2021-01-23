    public async void LoadWizard()
     {
        IsLoading = true; 
    
        StartWizard();
        var efData = Refresh(); 
    
        IsLoading = false;
    
        //update values of properties bound to the view
        PropertyBoundToView1 = efData.Prop1;
        PropertyBoundToView2 = efData.Prop2;
     }
    
    public void StartWizard()
    {
      //do something with data that are not bound to the view
    }
    
    public MyData Refresh()
    {
       return context.Set<MyData>().FirstOrDefault();
    }
