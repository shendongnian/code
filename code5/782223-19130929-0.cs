    static IEnumerable<T> PreOrderTraverse<T>(IEnumerable<T> nodes, Func<T, IEnumerable<T>> childrenSelector)
    {
    	foreach (var node in nodes)
    	{
    		yield return node;
    
    		foreach (var descendant in PreOrderTraverse(childrenSelector(node), childrenSelector))
    		{
    			yield return descendant;
    		}
    	}
    }
    
    static void Main(string[] args)
    {
    	/* Some code to load comments*/
    
    	var children = comments.ToLookup(c => c.PreviousID);
    
    	var result = PreOrderTraverse(children[0], c => children[c.ID]);
    
    	foreach (var comment in result)
    	{
    		Console.WriteLine(comment.Message);
    	}
    }
