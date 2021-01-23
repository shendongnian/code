    public class WebApiCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<HttpRequestMessage>(c => c
                .Do(x =>
                    x.Properties.Add(
                        HttpPropertyKeys.HttpConfigurationKey,
                        new HttpConfiguration())));
        }
    }
