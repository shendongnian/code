    Mapper.CreateMap<object1, MainModel>()
                            .ForMember(x => x.Property1, y => y.MapFrom(src => src));
    Mapper.CreateMap<object2, MainModel>()
                          .ForMember(x => x.Property2, y => y.MapFrom(src => src));
    Mapper..CreateMap<object3, MainModel>()
                       .ForMember(x => x.Property3, y => y.MapFrom(src => src));
    object1 obj1 = new object1();
    object2 obj2 = new object2();
    object3 obj3 = new object3();
    
    MainModel mm = AutoMapper.Mapper.Map<MainModel>(obj1);
    mm = AutoMapper.Mapper.Map(obj2, mm);
    mm = AutoMapper.Mapper.Map(obj3, mm);   
