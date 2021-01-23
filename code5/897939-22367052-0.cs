    public void TheCheckboxesShouldBeChecked()
    {
        AssertCheckState(Win.AreAllCheckboxesChecked());
    }
    public void TheCheckboxesShouldBeUnChecked()
    {
        AssertCheckState(Win.AreAllCheckboxesUnchecked());
    }
    private void AssertCheckState(bool value)
    {
        Assert.AreEqual(true, actual, "Checked state does not match");
    }
