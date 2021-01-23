    // Prepare the ticket
    HttpContext.Response.Cookies.Clear();
    FormsAuthenticationTicket ticket = 
       new FormsAuthenticationTicket(1, 
                                     "MYNAME", 
                                     DateTime.Now, 
                                     DateTime.Now.AddDays(10), // <<- Expires 10 days 
                                     true, 
                                     null);
    // Encrpt the ticket
    string encryptedCookie = FormsAuthentication.Encrypt(ticket);
    
    // Create new cookie
    HttpCookie cookie = new HttpCookie("MYNAME", encryptedCookie);
    cookie.Path = FormsAuthentication.FormsCookiePath;
    // THE MISSING LINE IS THIS ONE
    cookie.Espires = ticket.Expiration;   // <<- Uses current Ticket Expiration
    
    // Send the Cookie back to the browser
    HttpContext.Response.Cookies.Add(cookie);
