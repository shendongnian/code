    [Fact]
    public void ChangeService_StoresNewEntityInRepository_BasedOnProvidedId()
    {
        const string ExpectedName = "some name";
        var otherEntity = new OtherEntity { Name = ExpectedName };
        var mock = new Mock<IRepository>();
        var service = new ChangeService(mock.object);
        mock.Setup(m => m.GetEntityById(0)).Return(otherEntity);
        service.RegisterChange(0);
        mock.Verify(m => m.SaveEntity(It.Is<Entity>(e => e.Name == ExpectedName));
    } 
