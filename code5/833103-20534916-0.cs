    class TypeInformation
	{
		static readonly Regex TypeNameRegex = new Regex(@"^(?<TypeName>[a-zA-Z0-9_]+)(<(?<InnerTypeName>[a-zA-Z0-9_,<>\[\]]+)>)?(?<Array>(\[\]))?$", RegexOptions.Compiled);
		readonly List<TypeInformation> innerTypes = new List<TypeInformation>();
		public string TypeName
		{
			get;
			private set;
		}
		public bool IsArray
		{
			get;
			private set;
		}
		public bool IsGeneric
		{
			get { return innerTypes.Count > 0; }
		}
		public IEnumerable<TypeInformation> InnerTypes
		{
			get { return innerTypes; }
		}
		private void AddInnerType(TypeInformation type)
		{
			innerTypes.Add(type);
		}
		public static bool TryParse(string friendlyTypeName, out TypeInformation typeInformation)
		{
			typeInformation = null;
			// Try to match the type to our regular expression.
			var match = TypeNameRegex.Match(friendlyTypeName);
			// If that fails, the format is incorrect.
			if (!match.Success)
				return false;
			// Scrub the type name, inner type name, and array '[]' marker (if present).
			var typeName = match.Groups["TypeName"].Value;
			var innerTypeFriendlyName = match.Groups["InnerTypeName"].Value;
			var isArray = !string.IsNullOrWhiteSpace(match.Groups["Array"].Value);
			// Create the root type information.
			TypeInformation type = new TypeInformation
			{
				TypeName = typeName,
				IsArray = isArray
			};
			// Check if we have an inner type name (in the case of generics).
			if (!string.IsNullOrWhiteSpace(innerTypeFriendlyName))
			{
				// Split each type by the comma character.
				var innerTypeNames = Regex.Split(innerTypeFriendlyName, ",");
				// Iterate through all inner type names and attempt to parse them recursively.
				foreach (string innerTypeName in innerTypeNames)
				{
					TypeInformation innerType = null;
					var success = TypeInformation.TryParse(innerTypeName, out innerType);
					// If the inner type fails, so does the parent.
					if (!success)
						return false;
					// Success! Add the inner type to the parent.
					type.AddInnerType(innerType);
				}
			}
			// Return the parsed type information.
			typeInformation = type;
			return true;
		}
		public override string ToString()
		{
			// Create a string builder with the type name prefilled.
			var sb = new StringBuilder(this.TypeName);
			// If this type is generic (has inner types), append each recursively.
			if (this.IsGeneric)
			{
				sb.Append("<");
				// Get the number of inner types.
				int innerTypeCount = this.InnerTypes.Count();
				// Append each inner type's friendly string recursively.
				for (int i = 0; i < innerTypeCount; i++)
				{
					sb.Append(innerTypes[i].ToString());
					// Check if we need to add a comma to separate from the next inner type name.
					if (i + 1 < innerTypeCount)
						sb.Append(", ");
				}
				sb.Append(">");
			}
			// If this type is an array, we append the array '[]' marker.
			if (this.IsArray)
				sb.Append("[]");
			return sb.ToString();
		}
	}
