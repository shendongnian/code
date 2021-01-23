    public static class ClaimMappingExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllButMembersWithDataMemberAttribute<TSource, TDestination>(
                   this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            foreach (var property in sourceType.GetProperties())
            {
                var descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                var hasDataMemberAttribute = descriptor.Attributes.OfType<DataMemberAttribute>().Any();
                if (!hasDataMemberAttribute)
                    expression.ForSourceMember(property.Name, opt => opt.Ignore());
            }
            foreach (var property in destinationType.GetProperties())
            {
                var descriptor = TypeDescriptor.GetProperties(destinationType)[property.Name];
                var hasDataMemberAttribute = descriptor.Attributes.OfType<DataMemberAttribute>().Any();
                if (!hasDataMemberAttribute)
                    expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }
    }
