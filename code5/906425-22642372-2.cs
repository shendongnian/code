    HttpCookie aCookie = new HttpCookie("Session");
    Guid sessionGuid =  // Buisiness layer call to generate value
    String sessionID = sessionGuid.ToString();
    aCookie.Value = Helper.Protect(sessionID, "sessionID");
    aCookie.Expires = DateTime.Now.AddDays(30);
    Response.Cookies.Add(aCookie);                    
