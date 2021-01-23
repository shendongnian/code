    [TestMethod]
    [DataRow ("1!")
    [DataRow ("123456789")
    [DataRow ("123456789!")
    ...
    public void TestPasswordComplexity(string pass)
    {
        var result = _UserManager.ChangePasswordAsync(_TestUser.Id, "Password123!", pass).Result; //Changes the password.
        Assert.IsFalse(result.Succeeded);
    }
