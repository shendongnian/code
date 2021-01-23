    public MainViewModel:ObservableObject
    {
         public MainViewModel(){
    		//initalize everything
    		Childvm1.PropertyChanged += (s,e) {
    			if(e.PropertyName == "SelectedValue") {
    			   // Do what you want
    			}			
    		};
    	};
        
    }
