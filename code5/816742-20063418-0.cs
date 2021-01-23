	using AutoMapper;
	static class EntityConverter
	{
		static EntityConverter()
		{
			AutoMapper.Mapper.CreateMap<GDeerParkEntity.Busremove, ServiceProxy.Busremove>();
			AutoMapper.Mapper.CreateMap<GDeerParkEntity.Buseartag, ServiceProxy.Buseartag>();
			AutoMapper.Mapper.CreateMap<ServiceProxy.Busremove, GDeerParkEntity.Busremove>();
			AutoMapper.Mapper.CreateMap<ServiceProxy.Buseartag, GDeerParkEntity.Buseartag>();
		}
		public static TDestination Convert<TSource, TDestination>(TSource source)
		{
			return AutoMapper.Mapper.Map<TSource, TDestination>(source);
		}
	}
	var sourceEntity = new GDeerParkEntity.Busremove()
	var convertedEntity = EntityConverter.Convert<GDeerParkEntity.Busremove, ServiceProxy.Busremove>(sourceEntity);
