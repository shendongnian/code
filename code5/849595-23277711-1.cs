    [Test]
    public void RemoveAnswerValidatorTests_Validates_ValidInput_ReturnsTrue()
    {
        var autoMocker = new RhinoAutoMocker<RemoveAnswerValidator>();
        var fakeAnswerParameters = new FakeAnswerParameters()
        {
            AnswerID = 1,
            AnswerRepository = autoMocker.Get<IAnswerRepository>()
        };
        autoMocker.Inject<RemoveAnswerValidatorParameters>(fakeAnswer);
        var result = autoMocker.ClassUnderTest.Validates();
        Assert.IsTrue(result);
    }
