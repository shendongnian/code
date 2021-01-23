    public void BusinessToServiceTest()
    {
        var service = MockRepository.GenerateStub<IEntityTranslatorService>();
        var value = new object();
        NUnit.Framework.Assert.Throws<NotImplementedException>(
            () => BusinessToService(service, value)
            );
    }
