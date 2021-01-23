    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            if (<logic to validate username and password>)
            {
                //first reject the context, to signify that the client is not valid
                context.Rejected();
                
                //set the error message
                context.SetError("invalid_username_or_password", "Invalid userName or password" );
                //add a new key in the header along with the statusCode you'd like to return
                context.Response.Headers.Add("Change_Status_Code", new[] { ((int)HttpStatusCode.Unauthorized).ToString() }); 
                return;
            }
        }
