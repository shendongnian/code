        // Constructor
                 public MainPage()
                 {
                     InitializeComponent();
                      
                     
                      UserServiceReference.ServiceClient client = new ServiceClient();
                      
                       //Event handler after webservice completes operation.
                      client.UserDetailsCompleted += new EventHandler<UserDetailsCompletedEventArgs>                                            
        
                                      (serviceClient_UserDetailsCompleted);
                      client.UserDetailsAsync();
        
                 }    
             }
    
    
        //Completed event of the UserDetails
             public void serviceClient_UserDetailsCompleted(Object sender,UserDetailsCompletedEventArgs e )
                 {
                      try
                     {
        
                         var lsdUser = e.Result.ToList();
        
                         foreach (var userData in lsdUser)
                         {
                             
                             User userObj = new User();
                             userObj.UserName =userData[0].ToString(); 
                             userObj. userCity = userData[1].ToString();
                             userObj. userState=userData[2].ToString();
                             userObj. userGender=userData[3].ToString();
                             userObj. userAge=userData[4].ToString();
                             userObj. userDescription=userData[5].ToString();
                             
                             userList.Add(userObj);
        
                         }
        
                         //Binding Data to the userListBox
                         userListBox.ItemsSource = userList;
        
                     }
                     catch (Exception ex)
                     {
                         string message = ex.ToString();
                     }
        
                 }
    
    
