    public static bool IsPropertyChanged<TEntity>(this ObjectContext context, TEntity entityContainer, string propertyName)
				where TEntity : IEntityWithKey, IEntityWithRelationships
    {
        bool isModified = false;
        EdmMember edmMember = GetEdmMember(context, entityContainer, propertyName);
    
        switch (edmMember.BuiltInTypeKind)
    	{
    		case BuiltInTypeKind.NavigationProperty: /*navigation property*/
    						{
    							NavigationProperty navigationProperty = edmMember as NavigationProperty;
    							IRelatedEnd sourceRelatedEnd = entityContainer.RelationshipManager.GetRelatedEnd(navigationProperty.RelationshipType.FullName,
    																											 navigationProperty.ToEndMember.Name) as IRelatedEnd;
    							EntityState state = (EntityState.Added | EntityState.Deleted);
    							IEnumerable<IGrouping<IRelatedEnd, ObjectStateEntry>> relationshipGroups = GetRelationshipsByRelatedEnd(context, entityContainer, state);
    							foreach (var relationshipGroup in relationshipGroups)
    							{
    								IRelatedEnd targetRelatedEnd = (IRelatedEnd)relationshipGroup.Key;
    								if (targetRelatedEnd.IsEntityReference()
    									&& targetRelatedEnd.IsRelatedEndEqual(sourceRelatedEnd))
    								{
    									isModified = true;
    									break;
    								}
    							}
    						} break;
    
    		case BuiltInTypeKind.EdmProperty: /*scalar field*/
    						{
    							ObjectStateEntry containerStateEntry = null;
    							isModified = context.IsScalarPropertyModified(propertyName, entityContainer, out containerStateEntry);
    						} break;
    
    		default:
    						{
    							throw new InvalidOperationException("Property type not supported");
    						}
    				}
