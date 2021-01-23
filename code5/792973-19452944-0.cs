    public static class Extensions
    {
        public static IMappingExpression<SourceClass, TDestination> MapBase<TDestination>(
            this IMappingExpression<Source, TDestination> mapping)
            where TDestination: TargetBaseClass
        {
            // all base class mappings goes here
            return mapping
                .ForMember(dst => dst.TargetProperty1, opt => opt.MapFrom(src => src.SourceProperty1))
                .ForMember(dst => dst.TargetProperty2, opt => opt.MapFrom(src => src.SourceProperty2));
        }
    }
