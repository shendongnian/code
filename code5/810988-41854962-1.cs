    internal class WebApiCustomization<TControllerType> : ICustomization
        where TControllerType : ApiController
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customize<HttpRequestMessage>(c => c
                    .Without(x => x.Content)
                    .Do(x => x.Properties[HttpPropertyKeys.HttpConfigurationKey] =
                        new HttpConfiguration()));
                fixture.Customize<TControllerType>(c => c
                    .OmitAutoProperties()
                    .With(x => x.Request, fixture.Create<HttpRequestMessage>()));
    }
    }
     
