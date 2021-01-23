    var cookieAwareWebClient= //.... authenticate 
 
    var db = new ServiceReference.MyEntities(new Uri("MyDomain/WcfDataService.svc"));
                      
    db.SendingRequest += ( s,  arg) =>
    {                
        HttpWebRequest httpRequest = arg.Request as HttpWebRequest;
        httpRequest.CookieContainer = cookieAwareWebClient.CookieContainer;   // I made that property public                             
    };
            
    var myUsers = db.Users.ToList();
