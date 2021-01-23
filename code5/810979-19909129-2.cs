    internal class ApiControllerCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<HttpRequestMessage>(c => c
                .Without(x => x.Content)
                .Do(x => x.Properties[HttpPropertyKeys.HttpConfigurationKey] = 
                    new HttpConfiguration()));
            fixture.Customize<UsersController>(c => c
                .FromFactory(
                    new MethodInvoker(
                        new GreedyConstructorQuery()))
                .OmitAutoProperties()
                .With(x => x.Request, fixture.Create<HttpRequestMessage>()));
        }
    }
