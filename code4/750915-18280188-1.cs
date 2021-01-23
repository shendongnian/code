    [Test]
    public void BlairTest()
    {
        IniReader FakeINI = A.Fake<IniReader>();
        A.CallTo(() => FakeINI.ReadString("SignOn", "SendEnterClear", A<string>._)).Returns("N");
        A.CallTo(() => FakeINI.ReadString("SignOn", "SignOnKeyFirst", A<string>._)).Returns("N");
        // Personally, I'd use the above syntax for this one too, but I didn't
        // want to muck too much.
        A.CallTo(FakeINI).Where(x => x.Method.Name == "ReadInteger").WithReturnType<int>().Returns(1000);
        TestFile TestFileObject = new TestFile(FakeINI);
        List<string> ReturnedKeys = TestFileObject.GetLoginSequence();
        Assert.AreEqual(2, ReturnedKeys.Count, "Ensure all keystrokes are returned");
    }
