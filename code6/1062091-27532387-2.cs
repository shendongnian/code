    [When(@"I click the ""(.*)"" button")]
    public void WhenIClickTheButton(string buttonText)
    {
        Button button = browser.Button(Find.ByValue(buttonText).Or(Find.ByText(buttonText)));
        Assert.IsTrue(button.Exists, "No button with text '{0}' was found", buttonText);
        button.ClickNoWait();
    }
