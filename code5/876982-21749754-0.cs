    static void Main(string[] args)
    {
    	IEnumerable<char> a = "G010".ToCharArray();
    	IEnumerable<char> b = "G1820A".ToCharArray();
    	
    	int commonChars = FindCommonElements(a, b).Count();
    	Console.WriteLine(commonChars);
    
    	Console.ReadLine();
    }
    
    private static T[] FindCommonElements<T>(IEnumerable<T> source, IEnumerable<T> target)
    {
    	ILookup<T, T> lookup2 = target.ToLookup(i => i);
    
    	return (
    	  from group1 in source.GroupBy(i => i)
    	  let group2 = lookup2[group1.Key]
    	  from i in (group1.Count() < group2.Count() ? group1 : group2)
    	  select i
    	).ToArray();
    }
