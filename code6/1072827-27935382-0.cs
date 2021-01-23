    var compilation = ... //Get a compilation
	var results = new StringBuilder();
	// Traverse the symbol tree to find all namespaces, types, methods and fields.
	foreach (NamespaceSymbol ns in compilation.GetReferencedAssemblySymbol(mscorlib).GlobalNamespace.GetNamespaceMembers())
	{
		results.AppendLine();
		results.Append(ns.Kind);
		results.Append(": ");
		results.Append(ns.Name);
		foreach (var type in ns.GetTypeMembers())
		{
			results.AppendLine();
			results.Append("    ");
			results.Append(type.TypeKind);
			results.Append(": ");
			results.Append(type.Name);
			foreach (var member in type.GetMembers())
			{
				results.AppendLine();
				results.Append("       ");
				if (member.Kind == SymbolKind.Field || member.Kind == SymbolKind.Method)
				{
					results.Append(member.Kind);
					results.Append(": ");
					results.Append(member.Name);
				}
			}
		}
	}
