    var config = new MapperConfiguration(cfg =>
	{
		cfg.ForAllPropertyMaps(
			pm => pm.TypeMap.SourceType == typeof(<class of source object>),
			(pm, c) => c.ResolveUsing<object, object, object, object>(new IgnoreNullResolver(), pm.SourceMember.Name));
	});
    class IgnoreNullResolver : IMemberValueResolver<object, object, object, object>
    {
    	public object Resolve(object source, object destination, object sourceMember, object destinationMember, ResolutionContext context)
    	{
    		return sourceMember ?? destinationMember;
    	}
    }
