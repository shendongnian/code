    [SetUp]
    public void SetUp ()
    {
        _restSchemaValidator = new RestSchemaValidator();
        _testLoginEmail = UserFixture.SystemAccount.Email;
        _testLoginPassword = "password"; // the database contains a hashed password version of "password".
      AuthenticateClient(_testLoginEmail, _testLoginPassword);
    }
