    // Standard Setup helper
    private void SetupTesterApp(int someReturnParam, bool someTweak = true, ...)
    {
        mockTestEquipment = new Mock<ITestEquipment>();
        mockTestEquipment.Setup(_ => _.SomeMethod()).Returns(someReturnParam);
        mockTestEquipment.SetupGet(_ => _.SomeProperty).Returns(someTweak);
        t.AddTestEquipment(mockTestEquipment.Object);
    }
    
    private void VerifyStandardHappyScenario()
    {
       Assert.IsFalse(sut.InFaultedStatus);
       mockErrorHandler.Verify(_ => _.HandleError(It.IsAny<Exception>()), Times.Never);
       ... all other standard 'happy scenario' checks
    }
    ... + Similar method for for standard Failure Scenario verifications
