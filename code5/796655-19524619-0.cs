    [Test]
    public void Test1()
    {
        string testString = "test";
    
        mockOne.SetupGet(o => o.Val).Returns(testString);
        UnitUnderTest.CopyVal();
        mockTwo.VerifySet(t => t.Val = It.Is<string>(x => x == mockOne.Object.Val));
    }
