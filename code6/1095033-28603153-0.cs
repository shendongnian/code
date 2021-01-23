	AutoMapper.Mapper.CreateMap<Source,Dest>().
	ForMember((src => src.PropertyWithException), opt => opt.Ignore()).
	BeforeMap((src,dest)=>
	{
		try
		{
			dest.PropertyWithException = src.PropertyWithException;
		}
		catch
		{
			dest.PropertyWithException = some_default_value;
		}
	});
