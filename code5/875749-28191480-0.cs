    1) How to use Aweber .NET SDK to connect with Aweber account [Regular Account - (i.e.) Not the developer's one].
    
    Ans :- 1) Create a developer account - Visit https://labs.aweber.com/
    
           2) As you have successfully created the account you would see ConsumerKey,                            ConsumerSecret, & an AppId in your Application.
           
           3) Then for the fist time add the following code.
              
    string ConsumerKey = ConfigurationManager.AppSettings["AWeberConsumerKey"];
    string ConsumerSecret= ConfigurationManager.AppSettings["AWeberConsumerSecret"];
    
    Aweber.API api = new Aweber.API(ConsumerKey, ConsumerSecret);
    
    api.CallbackUrl = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/Authorize/Index";
                    
    api.get_request_token();
    
    Response.Cookies["oauth_token"].Value = api.OAuthToken;
    Response.Cookies["oauth_token_secret"].Value = api.OAuthTokenSecret;
    
    api.authorize();
    
    **Now create An Authorize controller in case of MVC or Authorize.aspx**
    string ConsumerKey = ConfigurationManager.AppSettings["AWeberConsumerKey"];
    string ConsumerSecret= ConfigurationManager.AppSettings["AWeberConsumerSecret"];
    
    API api = new API(ConsumerKey, ConsumerSecret);
    api.OAuthVerifier = Request["oauth_verifier"];
    Response.Cookies["access_token"].Value = api.get_access_token();
    Account account = api.getAccount();
    **Now you can apply yuor code to create, delete... subscribers from.to the list**
    
       When you run this code first the authorize page will appear where you need to add your Aweber regular account credentials.
    
      Once it's verified then you'll get access to the aweber's(Customer) account.
     
      **But you would not like the authorize page appear always whenever you run your application so you can omit it by doing the following steps.**
 
       
     1. Use the PHP script provided in How to create an app in Aweber?
        
        
     2. Copy the accessKey and accessSecretvariables to your C# code (these
            are the permanent keys).   
        
    
     3. Initialize the API with this code:
    
        string ConsumerKey = ConfigurationManager.AppSettings["AWeberConsumerKey"];
        string ConsumerSecret = ConfigurationManager.AppSettings["AWeberConsumerSecret"];    
        string accessKey = ConfigurationManager.AppSettings["accessKey"];
        string accessSecret = ConfigurationManager.AppSettings["accessSecret"];
        Aweber.API api = new Aweber.API(ConsumerKey, ConsumerSecret);
        api.OAuthToken = accessKey;
        api.OAuthTokenSecret = accessSecret;
        Account account = api.getAccount();
        **Now we'll code to create subscriber to a particular list** 
          int listid = int.Parse(ConfigurationManager.AppSettings["ListId"]);
          foreach (List list in account.lists().entries)
          {
               if (list.id == listid) Your List's ID **(Mylist - xxxxxxx)**
               {
                    foreach (Subscriber subscriber in ist.subscribers().entries)
                    {
                                   
                       if (subscriber.email.Equals(objRegModel.EmailID))
                       {
                             flag = false;
                             break;
                             
                             **Checks whether the similar subscriber exists on the list**
                        }
                        else
                        {
                             flag = true;
                         }
                     }
                if (flag == true)
                {
                 BaseCollection<Subscriber> target = list.subscribers();
                 SortedList<string, object> parameters = new SortedList<string, object>();
                 parameters.Add("email", objRegModel.EmailID);
                 parameters.Add("name", objRegModel.FirstName + " " + objRegModel.LastName);
                 Subscriber subscriber = target.create(parameters);
                 **This will add the subscriber to the specified list only if does not exist on that list.**
                }
            }
       }
       **To Delete a particluar subscriber from the list**       
