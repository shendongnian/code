    void AssertSessionIsValid(string username, int group, ...)
    {
        Assert.AreEqual(username, HttpContext.Current.Session["Username"]);
        Assert.AreEqual(group, HttpContext.Current.Session["Group"]);
        ...
    }
