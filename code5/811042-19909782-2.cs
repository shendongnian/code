    using(PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, (server + ":" + port), loginUsername, loginPassword))
    {
        //This will force the connection to the server and validate that the credentials are good
        //If the connection is good but the credentals are bad it will return "false", if the connection is bad it will throw a exception of some form.
        if(principalContext.ValidateCredentials(null, null))
        {
            // Rest of code here.
            //This is how you do the same check you where doing in your previous quesiton, notice that this is "userName", and "password" not "loginUsername" and "loginPassword"
            valid = principalContext.ValidateCredentials(userName,password);
        }
    }
