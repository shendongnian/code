    public void RaisePostBackEvent(string eventArgument)
    {
        int userCode = Convert.ToInt32(eventArgument);
    	User user = GetUserFromSession(userCode);
    	string userObjectKey = Guid.NewGuid().ToString();
    	Session[userObjectKey] = user;
    	Response.Redirect(string.Format("~/ViewContact1.aspx?userObjectKey={0}", userObjectKey);
    }
