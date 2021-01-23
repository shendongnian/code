    [WebMethod]
    public static User getUserByEmail(String Email)
    {
        return new User().getUserByEmail(Email);
    }
