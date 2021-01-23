    var typeHierarchies = new List<Type>();
	var type = this.GetType();		
	while(type.BaseType != null)
	{
		typeHierarchies.Add(type);
		type = type.BaseType;
	}
	FieldInfo[] l_Fields = typeHierarchies.SelectMany( x=>x.GetFields( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)).ToArray();
