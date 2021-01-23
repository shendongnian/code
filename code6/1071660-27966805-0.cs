    public class AddressConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Address>(c => 
                c.With(addr => addr.City, "foo"));
        }
    }
    fixture.Customize(new AddressConventions());
