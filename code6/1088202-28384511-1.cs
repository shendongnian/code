     public static class IgnoreReadOnlyExtensions
     {
            public static IMappingExpression<TSource, TDestination> IgnoreReadOnly<TSource, TDestination>(
                       this IMappingExpression<TSource, TDestination> expression)
            {
                var destType = typeof(TDestination);
                
                foreach (var property in destType.GetProperties())
                {
                    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(destType)[property.Name];
                    ReadOnlyAttribute attribute = (ReadOnlyAttribute) descriptor.Attributes[typeof(ReadOnlyAttribute)];
                    if(attribute.IsReadOnly == true)
                        expression.ForMember(property.Name, opt => opt.Ignore());
                }
                return expression;
            }
     }
