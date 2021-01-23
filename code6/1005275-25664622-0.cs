    public void BusinessToServiceTest()
    {
        var updateMacActivityPriorityTranslator = new UpdateMacActivityPriorityTranslator();
        var service = MockRepository.GenerateStub<IEntityTranslatorService>();
        var value = new object();
        NUnit.Framework.Assert.Throws<NotImplementedException>(
            () => updateMacActivityPriorityTranslator.BusinessToService(service, value)
            );
    }
