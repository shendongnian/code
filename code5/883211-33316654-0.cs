    public class AutoNonRecursiveMoqCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            if (fixture == null)
                throw new ArgumentNullException("fixture");
            fixture.Customizations.Add(
                new MethodInvoker(
                    new MockConstructorQuery()));
            fixture.ResidueCollectors.Add(new MockRelay());
        }
    }
