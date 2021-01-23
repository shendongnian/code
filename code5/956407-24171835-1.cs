    [TestMethod]
    public void Registeruser()
    {
        Registrationpage.GoTo();
        Registrationpage.Enterusername("user3451887");
        Registrationpage.EnterEmail("user3451887@stackoverflow.com");
    }
