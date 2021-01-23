	public class TypeName
	{
		public string Name;
		public bool IsGeneric;
		public bool IsArray;
		public List<TypeName> TypeArguments;
		public TypeName()
		{
			Name = null;
			IsGeneric = false;
			IsArray = false;
			TypeArguments = new List<TypeName>();
		}
		public override string ToString()
		{
			return FormatAsString( 0 );
		}
		private string FormatAsString( int indent )
		{
			var spacing = new string(' ', indent );
			string str = spacing + "Name: " + Name + "\r\n" +
			spacing + "IsGeneric: " + IsGeneric + "\r\n" +
			spacing + "IsArray: " + IsArray + "\r\n";
			if (IsGeneric)
			{
				str += spacing + "GenericParameters: {\r\n" + string.Join( spacing + "},{\r\n", TypeArguments.Select<TypeName,string>( t => t.FormatAsString( indent + 4 ) ) ) + spacing + "}\r\n";
			}
			return str;
		}
		
		public static TypeName Parse( string name )
		{
			int pos = 0;
			bool dummy;
			return ParseInternal( name, ref pos, out dummy );
		}
		
		private static TypeName ParseInternal( string name, ref int pos, out bool listTerminated )
		{
			StringBuilder sb = new StringBuilder();
			TypeName tn = new TypeName();
			listTerminated = true;
			while (pos < name.Length)
			{
				char c = name[pos++];
				switch (c)
				{
					case ',':
						if (tn.Name == null)
							tn.Name = sb.ToString();
						listTerminated = false;
						return tn;
					case '>':
						if (tn.Name == null)
							tn.Name = sb.ToString();
						listTerminated = true;
						return tn;
					case '<':
					{
						tn.Name = sb.ToString();
						tn.IsGeneric = true;
						sb.Length = 0;
						bool terminated = false;
						while (!terminated)
							tn.TypeArguments.Add( ParseInternal( name, ref pos, out terminated ) );
						var t = name[pos-1];
						if (t == '>')
							continue;
						else
							throw new Exception( "Missing closing > of generic type list." );
					}
					case '[':
						if (pos < name.Length)
						{
							if (name[pos++] == ']')
							{
								tn.IsArray = true;
								continue;
							}
						}
						throw new Exception( "Expecting ] after [ for array type." );
					default:
						sb.Append(c);
						continue;
				}
			}
			if (tn.Name == null)
				tn.Name = sb.ToString();
			return tn;
		}
	}
