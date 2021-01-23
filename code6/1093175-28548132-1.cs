    public class ViewItemProfile : AutoMapper.Profile
    {
    	protected override void Configure()
    	{
    		Mapper.CreateMap<Domain, View>()
    			.ForMember(x => x.ErrorRequestId, y => y.MapFrom(z => z.ErrorTypeId))
                .ForMember(x => x.Irrelevant, y => y.Ignore());
    	}
    }
