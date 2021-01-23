    protected void BindUserDetails(string userName)
    {
        UserService.ServiceSoapClient client = new UserService.ServiceSoapClient();
        XElement element = client.GetUserDetails(userName);
        if (element != null)
        {
            DataSet dsresult = new DataSet();
            XmlReader reader = element.CreateReader();
            dsresult.ReadXml(reader, XmlReadMode.Auto);
            gvUserDetails.DataSource = dsresult;
        }
        else
        {
            gvUserDetails.DataSource = null;
        }
        gvUserDetails.DataBind();
    }
