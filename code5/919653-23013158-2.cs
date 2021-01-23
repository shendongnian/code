    protected void BindUserDetails(string userName)
    {
        UserService.ServiceSoapClient client = new UserService.ServiceSoapClient();
        gvUserDetails.DataSource = ToDataSetOrNull(client.GetUserDetails(userName));
        gvUserDetails.DataBind();
    }
