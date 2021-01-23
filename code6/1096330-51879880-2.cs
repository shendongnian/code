     [Given(@"entered (.*) and (.*)")]
     public void GivenEnteredAnd(string username, string password)
     {
        var signin = new LoginPage(driver);
        signin.login(username, password);
     }
    [When(@"I press signin button")]
    public void WhenIPressSigninButton()
    {
       var submit = new LoginPage(driver);
       submit.ClickLogin();   
    }
