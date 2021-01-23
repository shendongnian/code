    public void SomeTest() {
        var mock = new Mock<ClassUnderTest>();
        mock.SetupGet(m => m.TestProperty).Returns("hi");
        var result = mock.Object.TestProperty;
        Assert.That(result, Is.EqualTo("hi"); // should pass
    }
