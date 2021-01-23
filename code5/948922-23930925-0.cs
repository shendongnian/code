    public dynamic Me()
    {
        var user = new LoggedInUser() { FirstName = "Test" };
        return new {FirstName = user.FirstName};
    }
