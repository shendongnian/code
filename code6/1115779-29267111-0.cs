    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }
    }
    
          .ForMember(dest => dest.CustomerId,
                           opts => opts.MapFrom(src => src.Id))
          .ForMember(dest => dest.VendorId,
                          opts => opts.MapFrom(src => src.VendorId))
            .IgnoreAllUnmapped();
