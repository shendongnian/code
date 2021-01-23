    [TestMethod]
    public void User_Confirmation_Is_Requested()
    {
        var mre = new ManualResetEvent(false);
        var vm = MyApplicationViewModel();
        ConfirmationRequestedEventArgs actual = null;
        vm.ConfirmationRequired += (sender, args) => {
        {
                actual = args;
                mre.Set();
        };
        vm.DoSomethingThatRequiresConfirmation();
        if (!mre.WaitOne(1000))
        {
            Assert.Fail("The event was never received.");
        }
        Assert.AreEqual("Whatever", actual.SomeProperty ?? string.Empty);
    }
