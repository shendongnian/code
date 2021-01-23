    [Test]
    public void TestUserNameSessionVariable()
    {
    //Login Code
    Assert.AreEqual("foo", HttpContext.Current.Session["Username"]);
    }
