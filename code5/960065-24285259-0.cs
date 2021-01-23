    [OperationContract]
    [WebInvoke(UriTemplate = "/IsRegisteredUser", BodyStyle = WebMessageBodyStyle.Bare, Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    public bool IsRegisteredUser(string emailOrUsername)
    {
      return this.GetUser(emailOrUsername) != null;
    }
