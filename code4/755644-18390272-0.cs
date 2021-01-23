    public List<UserData> GetUserModels(string id, string searchcriteria) 
    {    
        SSO_Methods sso = new SSO_Methods();
        List<UserData> userObject = sso.GetUserObject(id, searchcriteria);
        return userObject;
    }
