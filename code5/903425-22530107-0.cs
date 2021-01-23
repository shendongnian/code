    Guid userGuid;
    if(Request.LogonUserIdentity.IsAuthenticated == true)
    {
    WhoAmIRequest userRequest = new Microsoft.Crm.SdkTypeProxy.WhoAmIRequest();
    WhoAmIResponse user = (Microsoft.Crm.SdkTypeProxy.WhoAmIResponse)objCrmService.Execute(userRequest);
    userGuid = user.UserId;
    }
    else //ifd
    {
      userGuid = new Guid(Context.User.Identity.Name);
    }
 
