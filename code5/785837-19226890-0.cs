    Mapper.CreateMap<Model.Indicatiestelling, ClientRechtmatigheidDto>()
        .ForMember(dest => dest.HasFactBeoordelenRechtmatigheid, opt => opt.ResolveUsing(src => IndicatiestellingFactValueResolver.Resolve(src.IndicatiestellingFacts)))
        .ForMember(dest => dest.HasFactRechtmatig, opt => opt.ResolveUsing(src => IndicatiestellingFactValueResolver.Resolve(src.IndicatiestellingFacts)))
        .ForMember(dest => dest.SoortVoorziening, opt => opt.ResolveUsing(src => IndicatiestellingAnswerValueResolver.Resolve(src.IndicatiestellingAnswer)))
        .ForMember(dest => dest.ZZP, opt => opt.ResolveUsing(src => IndicatiestellingAnswerValueResolver.Resolve(src.IndicatiestellingAnswer)));
