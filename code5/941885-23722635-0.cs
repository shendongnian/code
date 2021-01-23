    if (User.Identity.IsAuthenticated == true)
    {
       .... 
    }
    else
    {
        return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
    }
