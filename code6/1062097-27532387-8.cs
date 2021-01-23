    [Then(@"I should see the validation error alert")]
    public void ThenIShouldSeeTheValidationErrorAlert()
    {
        var alert = StepHelper.GetAlertBox();
        Assert.IsTrue(alert.Message.Contains("An error has occurred"),
            "An alert was found, but contained the wrong message ('{0}')", alert.Message);
    }
