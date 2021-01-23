    public void TestMethod1()
    {
        var mockDoStuff = MockRepository.GenerateMock<IDoStuff>();
        mockDoStuff.Stub(x => x.DoStuff(Arg<Base>.Is.Anything)).Return(true);
        Assert.IsTrue(mockDoStuff.DoStuff(new BaseImplA()));
    }
