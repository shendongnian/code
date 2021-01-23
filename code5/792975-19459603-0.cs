    public enum WithBaseFor
    {
        Source,
        Destination,
        Both
    }
    public static class AutoMapperExntesions
    {
        public static IMappingExpression<TSource, TDestination> InheritMappingFromBaseType<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            WithBaseFor baseFor = WithBaseFor.Both,
            IMappingEngine mappingEngine = null,
            IConfigurationProvider configurationProvider = null)
        {
            Type sourceType = typeof (TSource);
            Type destinationType = typeof (TDestination);
            Type sourceParentType = baseFor == WithBaseFor.Both || baseFor == WithBaseFor.Source
                ? sourceType.BaseType
                : sourceType;
            Type destinationParentType = baseFor == WithBaseFor.Both || baseFor == WithBaseFor.Destination
                ? destinationType.BaseType
                : destinationType;
            mappingExpression
                .BeforeMap((sourceObject, destObject) =>
                {
                    if (mappingEngine != null)
                        mappingEngine.Map(sourceObject, destObject, sourceParentType, destinationParentType);
                    else
                        Mapper.Map(sourceObject, destObject, sourceParentType, destinationParentType);
                });
            TypeMap baseTypeMap = configurationProvider != null
                ? configurationProvider.FindTypeMapFor(sourceParentType, destinationParentType)
                : Mapper.FindTypeMapFor(sourceParentType, destinationParentType);
            if (baseTypeMap == null)
            {
                throw new InvalidOperationException(
                    string.Format("Missing map from {0} to {1}.", new object[]
                    {
                        sourceParentType.Name,
                        destinationParentType.Name
                    }));
            }
            foreach (PropertyMap propertyMap in baseTypeMap.GetPropertyMaps())
                mappingExpression.ForMember(propertyMap.DestinationProperty.Name, opt => opt.Ignore());
            return mappingExpression;
        }
    }
