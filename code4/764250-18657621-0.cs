        As in the above example I have used wcf service , and for the For the connectivity to DataBase we have used ADO.Net Entity Data Model.
        
           >>Then in the IService.cs we need to declare a method
              
              [OperationContract]
              List<string[]> UserDetails();
        
          >>Then in the Service.cs we need to define this Method
        
            public List<string[]> UserDetails()
            {
                List<string[]> lsdUserInfoDetails =
                                        new List<string[]>();
                string[] allUserList;
        
                try
                {
                    userDataConnection userContext = new
                                                       userDataConnection();
        
                    var query = (from Info in userContext.UserInfo
                                   select Info).ToList();
        
                    foreach(var userdetails in query)
                       {
                           allUserList = new string[8];
                           allUserList[0] = userdetails.UserName.ToString();
                           allUserList[1] = userdetails.UserCity.ToString();
                           allUserList[2] = userdetails.UserState.ToString();
                           allUserList[3] = userdetails.UserGender.ToString();
                           allUserList[4] = userdetails.UserAge.ToString();
                           allUserList[5] = userdetails.UserDescription.ToString();
        
                           lsdUserInfoDetails.Add(allUserList);  
                       }
        
                   
                }
                catch (Exception es)
                {
                   
                }
        
                return lsdUserInfoDetails;
            }
    
    And added the following code snipet in the MainPage.xaml.cs
    
    public partial class MainPage : PhoneApplicationPage
        {
           List<User> userList = new List<User>();
    
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
    
    
    
    
    
    
    
        /// <summary>
        /// User class
        /// </summary>
        public class User
        {
    
            private string userName;
            private string userID;
            private string userState;
            private string userCity;
            private string userGender;
            private string userAge;
    
    
            public string UserID
            {
                get
                {
                    return userID;
                }
                set
                {
                    userID = value;
                }
            }
    
            public string UserName
            {
                get
                {
                    return userName;
                }
                set
                {
                    userName = value;
                }
            }
    
            public string UserState
            {
                get
                {
                    return userState;
                }
                set
                {
                    userState = value;
                }
            }
    
            public string UserCity
            {
                get
                {
                    return userCity;
                }
                set
                {
                    userCity = value;
                }
            }
    
            public string UserAge
            {
                get
                {
                    return userAge;
                }
                set
                {
                    userAge = value;
                }
            }
    
            public string UserGender
            {
                get
                {
                    return userGender;
                }
                set
                {
                    userGender = value;
                }
            }
    
        }
    
     
            
    
    
            
          
