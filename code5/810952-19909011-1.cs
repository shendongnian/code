    [Test, TestCaseSource(typeof(ModelTestCaseSource), "GetTestCases")]
    public void RegisterUserTest(RegistrationData registrationData)
    {
        RegisterNewUser registration = new RegisterNewUser(this.driver);
        this.driver.Navigate().GoToUrl(baseURL + "/mercuryregister.php");
        registration.registerNewUser(registrationData);
    }
