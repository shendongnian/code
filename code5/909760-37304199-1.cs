    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
    
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
    
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
    
    public class CustomerProfile : Profile
    {
        protected override void Configure()
        {
            var nestedMap = CreateMap<Address, CustomerDto>()
                .IgnoreAllNonExisting();
    
            CreateMap<Customer, CustomerDto>()
                .FlattenNested(s => s.Address, nestedMap);
        }
    }
    
    [TestFixture]
    public class CustomerProfileTests
    {
        [Test]
        public void Test()
        {
            Mapper.Initialize(c => c.AddProfile<CustomerProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }
