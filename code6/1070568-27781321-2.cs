    Mapper.CreateMap<List<Customer>, Customer>()
		  .ForMember(t => t.Name, 
					 opt => opt.MapFrom(s => s.FirstOrDefault().Name))
		  .ForMember(t => t.Salary, 
					 opt => opt.MapFrom(s => s.FirstOrDefault().Salary))
		  .ForMember(t => t.CountryCode, 
					 opt => opt.MapFrom(s => s.FirstOrDefault().CountryCode));
    var oCustomer = oCust.Where(x => x.CountryCode == "US").ToList(); ;
    Customer viewModel = Mapper.Map<List<Customer>, Customer>(oCustomer);		  
