    public static PropertyInfo GetForeignKey(DbContext context, Type type, Type related)
    {
	    StructuralType edmType = GetCSpaceType(context, type);
	    StructuralType parentEdmType = GetCSpaceType(context, related);
	    var members = edmType
						    .MetadataProperties
						    .Where(mp => mp.Name == "Members")
						    .FirstOrDefault();
	    if (members != null && members.Value != null)
	    {
		    List<NavigationProperty> navProps = ((ICollection<EdmMember>)members.Value)
											    .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.NavigationProperty)
											    .Cast<NavigationProperty>()
											    .Where(p =>
												    ((AssociationType)p.RelationshipType).IsForeignKey
											    )
											    .ToList();
		    NavigationProperty navProp = navProps
										    .FirstOrDefault(p => ((RefType)p.ToEndMember.TypeUsage.EdmType).ElementType.FullName == parentEdmType.FullName);
		    if (navProp != null)
		    {
			    var dependent = navProp.GetDependentProperties().ToList();
			    if (dependent.Count > 0)
			    {
				    return type.GetProperty(dependent[0].Name);
			    }
		    }
	    }
	    return null;
    }
