    [Test]
    public void CreateShouldThrowIfModelTestIsNull()
    {
        var testModel = model.ToEntity();
        var sut  =  new TestRepository();
        testModel.test = null;
        try {
            sutCreate(testModel);
            Assert.Fail("Expected Exception");
        } catch(InvalidOperationException ex) {
            Assert.AreEqual("nanana.", ex.Message);
        }
    }
