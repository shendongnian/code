    public class CustomObjectGeneration : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(GenerateAddress); 
            fixture.Register(GeneratePersonName);
        }
        private Address GenerateAddress()
        {
            return new Address(Faker.Address.StreetAddress(), Faker.Address.SecondaryAddress(), Faker.Address.City(),
                Faker.Address.ZipCode(), Faker.Address.UsState(), Faker.Address.Country());
        }
        private PersonName GeneratePersonName()
        {
            
            return new PersonName(Faker.Name.Prefix(), Faker.Name.First(), Faker.Name.First(), Faker.Name.Last(), Faker.Name.Suffix());
        }
    }
