    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddDataReaderMapping();
        cfg.CreateMap<IDataRecord, PersonModel>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.GetValue(src.GetOrdinal("Identificator"))))
        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.GetValue(src.GetOrdinal("First_Name"))))
        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.GetValue(src.GetOrdinal("Last_Name"))));
    });
    var mapper = config.CreateMapper();
    var people = mapper.Map<IDataReader, List<PersonModel>>(dt.CreateDataReader());
