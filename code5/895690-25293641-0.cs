    public override void Validate(string userName, string password)
    {
        if(String.IsNullOrEmpty(userName) && String.IsNullOrEmpty(password))
        {
            var requestedOperation = 
                OperationContext.Current.IncomingMessageHeaders.Action.Split('/').Last();
            if("myAnonymousOperation" == requestedOperation)
            {        
                // Allow anonymous access here.
                return;
            }
        }
        // Allow/deny users that provide credentials
        ValidateOtherCredentials(userName, password);
    }
