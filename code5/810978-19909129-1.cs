    internal class ApiControllerCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<UsersController>(c => c
                .FromFactory(
                    new MethodInvoker(
                        new GreedyConstructorQuery()))
                .OmitAutoProperties());
        }
    }
