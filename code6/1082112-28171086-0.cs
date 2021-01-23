    public static void Main(string args[])
    {
    	var lists = new List<IList>
        {
            new List<Foo>(),
            new List<Bar>(),
            new List<Bar>()
        };
    
        ReverseLists(lists);
    }
    
    public static void MyReverse(IList source)
    {
        var length = source.Count;
        var hLength = length / 2;
        for (var i = 0; i < hLength; i++)
        {
            var temp = source[i];
            source[i] = source[length - 1 - i];
            source[length - 1 - i] = temp;
        }
    }
    
    public static void ReverseLists(List<IList> sourceLists)
    {
        foreach (var sourceList in sourceLists)
        {
            MyReverse(sourceList); // Error: Type arguments cannot be inferred from usage
        }
    }
    public class Foo
    {
    }
    public class Bar
    {
    }
