    [When(@"I click OK in the validation error alert")]
    public void WhenIClickOKInTheValidationErrorAlert()
    {
        var alert = StepHelper.GetAlertBox();
        Assert.IsTrue(alert.Message.Contains("An error has occurred"),
            "An alert was found, but contained the wrong message ('{0}')", alert.Message);
        alert.ForceClose();
    }
