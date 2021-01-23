    Membership.ApplicationName = "MyWebService";
    MembershipUser user = Membership.Providers["WebServiceMembershipProvider"].GetUser(serviceUsername, false);
    profile = ProfileBase.Create(serviceUsername);
    profile.Initialize(user.UserName, true);
    var myProperty = profile.GetPropertyValue("webservice_property1");
