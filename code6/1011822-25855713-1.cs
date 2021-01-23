    HttpContext httpContext = HttpContext.Current;
    
    //Extracting credentials:
    string authHeader = this.httpContext.Request.Headers["Authorization"];
    if (authHeader != null && authHeader.StartsWith("Basic")) {
	    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
        int seperatorIndex = usernamePassword.IndexOf(':');
	
	    username = usernamePassword.Substring(0, seperatorIndex);
	    password = usernamePassword.Substring(seperatorIndex + 1);
	} else {
	    //Handle what happens if that isn't the case
	    throw new Exception("The authorization header is either empty or isn't Basic.");
	}
