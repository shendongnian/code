    internal class ApiControllerCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<ApiController>(c => c
                .FromFactory(
                    new MethodInvoker(
                        new GreedyConstructorQuery())));
        }
    }
