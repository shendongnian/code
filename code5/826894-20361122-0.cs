    [Test]
    public void PasswordPolicy_should_reject_short_passwords()
    {
       PasswordPolicy policy = new PasswordPolicy();
       bool result = policy.Validate("pwd");
       Assert.IsFalse(result);
    }
