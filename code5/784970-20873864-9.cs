    public class LookupProfile : Profile
    {
        protected override void Configure()
        {
            //Use whatever datatype is appropriate: decimal, int, short, etc
            CreateMap<Lookup, SelectListItem<int>>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.LookupId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Value));
    
        }
    }
