    internal class UserDataCustomization : ICustomization
    {
        private readonly string userData;
        public UserDataCustomization(string userData)
        {
            this.userData = userData;
        }
        public void Customize(IFixture fixture)
        {
            fixture.Customize<FormsAuthenticationTicket>(c =>
                c.FromFactory(
                    new MethodInvoker(
                        new GreedyConstructorQuery())));
            fixture.Customizations.Add(new UserDataBuilder(this.userData));
        }
        private class UserDataBuilder : ISpecimenBuilder
        {
            private readonly string userData;
            public UserDataBuilder(string userData)
            {
                this.userData = userData;
            }
            public object Create(object request, ISpecimenContext context)
            {
                var pi = request as ParameterInfo;
                if (pi != null && pi.Name == "userData")
                    return this.userData;
                return new NoSpecimen();
            }
        }
    }
