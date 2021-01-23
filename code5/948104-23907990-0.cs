    protected override void OnNavigatedTo(NavigationEventArgs e) 
    { 
           // Store test data. 
           List<CustomContact> listContacts = new List<CustomContact>(); 
 
 
           // Request parameter. The identification of the source page. 
           string parameter = NavigationContext.QueryString["listOfContact1"]; 
                     
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
