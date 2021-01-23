	public class TypeName
	{
		public string Name;
		public bool IsGeneric;
		public List<ArrayDimension> ArrayDimensions;
		public List<TypeName> TypeArguments;
		public class ArrayDimension
		{
			public int Dimensions;
			public ArrayDimension()
			{
				Dimensions = 1;
			}
			public override string ToString()
			{
				return "[" + new String(',', Dimensions - 1) + "]";
			}
		}
		public TypeName()
		{
			Name = null;
			IsGeneric = false;
			ArrayDimensions = new List<ArrayDimension>();
			TypeArguments = new List<TypeName>();
		}
		public static string MatchStructure( TypeName toMatch, TypeName toType )
		{
			return null;
		}
		public override string ToString()
		{
			string str = Name;
			if (IsGeneric)
				str += "<" + string.Join( ",", TypeArguments.Select<TypeName,string>( tn => tn.ToString() ) ) + ">";
			foreach (ArrayDimension d in ArrayDimensions)
				str += d.ToString();
			return str;
		}
		public string FormatForDisplay( int indent = 0 )
		{
			var spacing = new string(' ', indent );
			string str = spacing + "Name: " + Name + "\r\n" +
			spacing + "IsGeneric: " + IsGeneric + "\r\n" +
			spacing + "ArraySpec: " + string.Join( "", ArrayDimensions.Select<ArrayDimension,string>( d => d.ToString() ) ) + "\r\n";
			if (IsGeneric)
			{
				str += spacing + "GenericParameters: {\r\n" + string.Join( spacing + "},{\r\n", TypeArguments.Select<TypeName,string>( t => t.FormatForDisplay( indent + 4 ) ) ) + spacing + "}\r\n";
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
						ArrayDimension d = new ArrayDimension();
						tn.ArrayDimensions.Add( d );
					analyzeArrayDimension: //label for looping over multidimensional arrays
						if (pos < name.Length)
						{
							char nextChar = name[pos++];
							switch (nextChar)
							{
								case ']':
									continue; //array specifier terminated
								case ',': //multidimensional array
									d.Dimensions++;
									goto analyzeArrayDimension;
								default:
									throw new Exception( @"Expecting ""]"" or "","" after ""["" for array specifier but encountered """ + nextChar + @"""." );
							}
						}
						throw new Exception( "Expecting ] or , after [ for array type, but reached end of string." );
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
