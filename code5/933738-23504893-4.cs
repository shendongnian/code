    public class BCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<BaseImplB>(c => c.Without(x => x.Value));
        }
    }
