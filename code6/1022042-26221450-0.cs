        public override async void ViewDidAppear (bool animated)
        {
            base.ViewDidAppear (animated);
                    //as the resource loading is async. whe need to refresh table here
    
    Task.Run (async delegate {
    				await DatesTask().ContinueWith(() => {
                       InvokeOnMainThread (delegate {  
                                TableView.ReloadData ();
                              });
    				});
    			});
           
            
         }
