    Mapper.CreateMap<Person, IFoo>()
        .ForMember(dest => dest.Bar, opt => opt.MapFrom(src => src));
    Mapper.CreateMap<Person, IBar>();
    IFoo foo = Mapper.Map<IFoo>(person);
    Console.WriteLine(foo.Bar.Name); // Peter
    Console.WriteLine(foo.Id); // 1
