    public async void LoadWizard()
    {
       IsLoading = true; //Need the UI to update immediately 
       
       App.Current.Dispatcher.Invoke((Action)(() => { }), DispatcherPriority.Render);
    
       //Now lets run the rest (This may take a couple seconds)
       StartWizard();
       Refresh(); 
    }
