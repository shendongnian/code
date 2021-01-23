    public Response MyService(string userName, string password, <... other params>)
    {   
        Identity userIdentity;
        string errorMessage = string.Empty;
        if(TryAuthorize(userName, password, out errorMessage))
        {
            //do stuff
        }
        else
        {
            return Response.ErrorResponse(errorMessage)
        }
    }
