    class MainClass
    {
		static readonly int RootIndentLevel = 2;
		static readonly string InputString = @"BogusClass<A,B,Vector<C>>";
		public static void Main(string[] args)
		{
			TypeInformation type = null;
			Console.WriteLine("Input  = {0}", InputString);
			var success = TypeInformation.TryParse(InputString, out type);
			if (success)
			{
				Console.WriteLine("Output = {0}", type.ToString());
				Console.WriteLine("Graph:");
				OutputGraph(type, RootIndentLevel);
			}
			else
				Console.WriteLine("Parsing error!");
		}
		static void OutputGraph(TypeInformation type, int indentLevel = 0)
		{
			Console.WriteLine("{0}{1}{2}", new string(' ', indentLevel), type.TypeName, type.IsArray ? "[]" : string.Empty);
			foreach (var innerType in type.InnerTypes)
				OutputGraph(innerType, indentLevel + 2);
		}
	}
