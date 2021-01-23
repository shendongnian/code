    protected override void OnNavigatedTo(NavigationEventArgs e) 
    { 
           // Store test data. 
           List<CustomContact> listContacts = new List<CustomContact>(); 
           string msg;
           if (NavigationContext.QueryString.TryGetValue("msg", out msg))
           {
               tblk_GroupName.Text = msg;
           }
    
           // Request parameter. The identification of the source page. 
           string parameter = NavigationContext.QueryString["listOfContact"]; 
    
           switch (parameter) 
           { 
               case "1": 
                   var myParameter = NavigationService.GetLastNavigationData(); 
    
    
                   if (myParameter != null) 
                   { 
                       listContacts = (List<CustomContact>)myParameter; 
                   } 
                   break; 
           }
    }
