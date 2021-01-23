		public static IEnumerable<string> GetNamespaces(INamedTypeSymbol symbol)
		{
			var current = symbol.ContainingNamespace;
			while (current != null)
			{
				if (current.IsGlobalNamespace)
					break;
				yield return current.Name;
				current = current.ContainingNamespace;
			}
		}
		public static string GetFullNamespace(INamedTypeSymbol symbol)
		{
			return string.Join(".", GetNamespaces(symbol).Reverse());
		}
		public static string GetFullTypeName(INamedTypeSymbol symbol)
		{
			return string.Join(".", GetNamespaces(symbol).Reverse().Concat(new []{ symbol.Name }));
		}
