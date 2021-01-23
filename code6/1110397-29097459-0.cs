    [Test]
    public void TestMethod1()
    {
        using (Fake.CreateScope())
        {
            sut.TestedMethod(); //TestedMethod calls myFakedObject.AssertedMethod() again...
            A.CallTo(() => myFakedObject.AssertedMethod()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
