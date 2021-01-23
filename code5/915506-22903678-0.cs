     if (sessionCookie == null)
     {
         postRequest.CookieContainer = new CookieContainer();// This for login service
     }
     else
     {
         postRequest.CookieContainer = sessionCookie; // Using the login cookie for  remaining webservices                                     
     }
