    Mapper.CreateMap<CustomerProfile, CustomerViewModel>()
        // Ignore Email since it's mapped by the User to CustomerViewModel mapping.
        .ForMember(dest => dest.Email, opt => opt.Ignore());
	
    Mapper.CreateMap<User, CustomerViewModel>()
        .ConstructUsing(src => Mapper.Map<CustomerViewModel>(src.CustomerProfile))
        // Ignore FirstName/LastName since they're mapped above using ConstructUsing.
        .ForMember(dest => dest.FirstName, opt => opt.Ignore())
        .ForMember(dest => dest.LastName, opt => opt.Ignore());
