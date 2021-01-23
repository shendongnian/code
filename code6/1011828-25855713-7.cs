    HttpContext httpContext = HttpContext.Current;
    
    string authHeader = this.httpContext.Request.Headers["Authorization"];
    if (authHeader != null && authHeader.StartsWith("Basic")) {
        string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
	    Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
        int seperatorIndex = usernamePassword.IndexOf(':');
	
	    var username = usernamePassword.Substring(0, seperatorIndex);
	    var password = usernamePassword.Substring(seperatorIndex + 1);
	} else {
	    //Handle what happens if that isn't the case
	    throw new Exception("The authorization header is either empty or isn't Basic.");
	}
