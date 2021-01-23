    public class CustomResolver : IValueResolver<ExampleClass, ExampleClass, Dictionary<int, string[]>>
    {
    	public Dictionary<int, string[]> Resolve(ExampleClass source, ExampleClass destination, Dictionary<int, string[]> member, ResolutionContext context)
    	{
            // logic to iterate through the dictionarys and resolve into dictionary containing values that you want.
    	}
    }
