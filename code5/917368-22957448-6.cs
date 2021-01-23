    private static EdmMember GetEdmMember<TEntity>(this ObjectContext context, TEntity entityContainer, string propertyName)
     {
        EdmMember edmMember = null;
        EntityType entityType = context.MetadataWorkspace.GetItem<EntityType>(entityContainer.GetType().FullName, DataSpace.CSpace);
        IEnumerable<EdmMember> edmMembers = entityType.MetadataProperties.First(p => p.Name == "Members").Value as IEnumerable<EdmMember>;
        edmMember = edmMembers.FirstOrDefault(item => item.Name == propertyName);
        if (edmMember == null)
        	throw new ArgumentException(
       							string.Format("Cannot find property metadata: property '{0}' in '{1}' entity object", propertyName, entityType.Name));
        return edmMember;
    }
