	public static string[] GetForeignKeys(DbContext context, Type type)
	{
		StructuralType edmType = GetCSpaceType(context, type);
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
			List<EdmProperty> foreignKeys = navProps
											.SelectMany(p => p.GetDependentProperties())
											.ToList();
			return foreignKeys.Select(p => p.Name).ToArray();
		}
		return null;
	}
    
	private static StructuralType GetCSpaceType(DbContext context, Type type)
	{
		MetadataWorkspace workspace = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
		EdmType ospaceType = workspace.GetType(type.Name, type.Namespace, DataSpace.OSpace);
		return workspace.GetEdmSpaceType((StructuralType)ospaceType);
	}
