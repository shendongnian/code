    public void Main()
    {
      var validLoginInfo = new LoginInfo(loginText.Text)
      var isValid = new LoginValidator(loginText.Text, passwordText.Text, validLoginInfo).Validate();
      ...
    }
