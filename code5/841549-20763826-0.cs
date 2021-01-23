    public static class AutoMapperWebConfiguration
    {
    	public static void Configure()
    	{
    		Mapper.Initialize(cfg =>
    		{
    			cfg.AddProfile(new CustomerMapper());
    			cfg.AddProfile(new CustomerAddressMapper());
    		});
    	}
    }
    
    public class CustomerMapper : Profile
    {
    	protected override void Configure()
    	{
    		Mapper.CreateMap<CustomerViewModel, Customer>().ForMember(customer => customer.Address, expression => expression.MapFrom(viewModel => viewModel.Address));
    	}
    }
    
    public class CustomerAddressMapper : Profile
    {
    	protected override void Configure()
    	{
    		Mapper.CreateMap<CustomerAddressViewModel, Address>();
    	}
    }
