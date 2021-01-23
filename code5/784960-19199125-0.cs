    public class LookupProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Lookup, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => SqlFunctions.StringConvert((double)src.LookupId)))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Value));
    
        }
    }
